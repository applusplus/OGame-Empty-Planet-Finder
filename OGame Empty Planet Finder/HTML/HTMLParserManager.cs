using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using NLog;
using OGameEmptyPlanetFinder.Exceptions;
using OGameEmptyPlanetFinder.OGame;
using OGameEmptyPlanetFinder.Utilities;

namespace OGameEmptyPlanetFinder.HTML
{
    public class HTMLParserManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private HtmlNode getDocumentNode(Stream htmlCodeStream)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlCodeStream.Position = 0;
            htmlDocument.Load(htmlCodeStream, Encoding.UTF8);
            return htmlDocument.DocumentNode;
        }

        //public List<ComboboxItem> getServers(Stream htmlStream) 
        //{
        //    String filterServers = ".//select[contains(@id, 'serverLogin')]/option";
        //    List<ComboboxItem> list = new List<ComboboxItem>();
        //    try
        //    {
        //        HtmlNode rootNode = getDocumentNode(htmlStream);
        //        String key = "";
        //        String value = "";
        //        HtmlNodeCollection nodeColl = rootNode.SelectNodes(filterServers);
        //        if (nodeColl != null)
        //        {
        //            foreach (HtmlNode node in nodeColl)
        //            {
        //                key = node.NextSibling.InnerText.Trim();
        //                value = node.GetAttributeValue("value", "").Trim();
        //                list.Add(new ComboboxItem(key, value));
        //            }
        //        } 
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }          
        //    return list;
        //}

        public ResourceEntity getResources(HtmlNode rootNode)
        {
            ResourceEntity resources = null;
            try
            {   
                HtmlNode selectedNode = rootNode.SelectSingleNode(".//span[@id='resources_metal']");
                int metal = Convert.ToInt32(selectedNode.InnerText.Trim().Replace(".", ""));
                selectedNode = rootNode.SelectSingleNode(".//span[@id='resources_crystal']");
                int crystal = Convert.ToInt32(selectedNode.InnerText.Trim().Replace(".", ""));
                selectedNode = rootNode.SelectSingleNode(".//span[@id='resources_deuterium']");
                int deut = Convert.ToInt32(selectedNode.InnerText.Trim().Replace(".", ""));
                selectedNode = rootNode.SelectSingleNode(".//span[@id='resources_energy']");
                int energy = Convert.ToInt32(selectedNode.InnerText.Trim().Replace(".", ""));
                selectedNode = rootNode.SelectSingleNode(".//span[@id='resources_darkmatter']");
                int darkmatter = Convert.ToInt32(selectedNode.InnerText.Trim().Replace(".", ""));
                resources = new ResourceEntity(metal, crystal, deut, darkmatter, energy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resources;
        }

        public void fillPlayerInfoWithMetaData(Stream htmlStream)
        {
            try
            {
                HtmlNode rootNode = getDocumentNode(htmlStream);
                if (rootNode != null)
                {
                    try
                    {
                        PlayerInfo.Instance.Resources = getResources(rootNode);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("HTMLParserManager.fillPlayerInfoWithMetaData.getResources: " + ex);
                    }                   

                    string UniverseName = rootNode.SelectSingleNode(@".//title").InnerText.Trim();
                    PlayerInfo.Instance.UniverseName = Regex.Match(UniverseName, @"^(.*) OGame$").Groups[1].Value;
                    PlayerInfo.Instance.UniverseID = getMetaAttributeValue(rootNode, "ogame-universe");
                    PlayerInfo.Instance.UniverseSpeed = getMetaAttributeValue(rootNode, "ogame-universe-speed");
                    PlayerInfo.Instance.PlayerID = getMetaAttributeValue(rootNode, "ogame-player-id");
                    PlayerInfo.Instance.PlayerName = getMetaAttributeValue(rootNode, "ogame-player-name");
                    PlayerInfo.Instance.AllianceID = getMetaAttributeValue(rootNode, "ogame-alliance-id");
                    PlayerInfo.Instance.AllianceName = getMetaAttributeValue(rootNode, "ogame-alliance-name");
                    PlayerInfo.Instance.AllianceTag = getMetaAttributeValue(rootNode, "ogame-alliance-tag");
                    try
                    {
                        PlayerInfo.Instance.CurrentPlanet = new PlanetEntity(new Coordinates(getMetaAttributeValue(rootNode, "ogame-planet-coordinates")), 
                            getMetaAttributeValue(rootNode, "ogame-planet-name"), getMetaAttributeValue(rootNode, "ogame-planet-id"),
                            getMetaAttributeValue(rootNode, "ogame-planet-type"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("fillPlayerInfoWithMetaData.PlanetEntity: " + ex);
                        logger.Error("fillPlayerInfoWithMetaData.PlanetEntity: " + ex);
                    }
                    PlayerInfo.Instance.Planets = new List<PlanetEntity>();
                    HtmlNodeCollection planetNodes = rootNode.SelectNodes(@".//div[@id='myWorlds' or @id='myPlanets']/div[@id='planetList']/div[contains(@class, 'planet')]");
                    if(planetNodes != null)
                    {
                        foreach (HtmlNode planetNode in planetNodes)
                        {
                            PlanetEntity planetEntity = new PlanetEntity();
                            planetEntity.PlanetID = Regex.Match(planetNode.GetAttributeValue("id", ""), @"planet-(\d*)").Groups[1].Value;
                            planetEntity.PlanetType = "planet";
                            HtmlNode spanNode = planetNode.SelectSingleNode(@".//span[contains(@class, 'planet-name')]");
                            planetEntity.PlanetName = spanNode.InnerText;
                            spanNode = planetNode.SelectSingleNode(@".//span[contains(@class, 'planet-koords')]");
                            planetEntity.Coordinates = new Coordinates(spanNode.InnerText);
                            PlayerInfo.Instance.Planets.Add(planetEntity);
                        }
                    }
                }
                else
                {
                    throw new NullReferenceException("HTMLParserManager.fillPlayerInfoWithMetaData: HtmlNode rootNode is NULL!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool isAlertVisible(Stream htmlStream)
        {
            bool isVisible = false;
            try
            {
                HtmlNode rootNode = getDocumentNode(htmlStream).SelectSingleNode(".//div[@id='attack_alert']");
                if (rootNode != null)
                {
                    isVisible = "visibility:visible;".Equals(rootNode.GetAttributeValue("style", "visibility:hidden;"));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
            }
            return isVisible;
        }

        private string getMetaAttributeValue(HtmlNode node, string meta)
        {
            return node.SelectSingleNode(@".//meta[@name='" + meta + "']").GetAttributeValue("content", "");
        }

        public List<Coordinates> getEmptyPlanets(Stream htmlStream, int galaxy, int system, int startIndex, int stopIndex)
        {
            List<Coordinates> emptyPlanets = new List<Coordinates>();
            HtmlNode rootNode = getDocumentNode(htmlStream);
            HtmlNodeCollection nodeCollection = rootNode.SelectNodes(".//table[contains(@id, 'galaxytable')]/tbody/tr");
            if (nodeCollection == null || nodeCollection.Count < 1)
            {
                throw new SessionClosedException("The Session was closed by the server, please try again.");
            }
            foreach (HtmlNode node in nodeCollection)
            {
                HtmlNode positionNode = node.SelectSingleNode(".//td[contains(@class, 'position')]");
                int position = positionNode!=null ? Convert.ToInt32(positionNode.InnerText) : 0;
                if (position >= startIndex && position <= stopIndex)
                {
                    HtmlNode emptyPlanet = node.SelectSingleNode(".//td[contains(@class, 'planetEmpty')]");
                    HtmlNode destroyedPlanet = node.SelectSingleNode(".//a[contains(@rel, 'player99999')]");
                    if (emptyPlanet != null || destroyedPlanet != null)
                    {
                        emptyPlanets.Add(new Coordinates(galaxy, system, position, (destroyedPlanet != null)));
                    }
                }
            }
            return emptyPlanets;
        }

        public List<DFCoordinates> getDebrisFields(Stream htmlStream, int minRes)
        {
            List<DFCoordinates> debrisFields = new List<DFCoordinates>();
            HtmlNode rootNode = getDocumentNode(htmlStream);
            HtmlNodeCollection nodeCollection = rootNode.SelectNodes(".//div[contains(@id, 'debris')]");
            if (nodeCollection != null && nodeCollection.Count > 0)
            {
                foreach (HtmlNode node in nodeCollection)
                {
                    HtmlNode debrisPosNode = node.SelectSingleNode(".//span[contains(@id, 'pos-debris')]");
                    HtmlNodeCollection debrisNodes = node.SelectNodes(".//li[contains(@class, 'debris')]");
                    List<int> contentList = new List<int>(3);
                    foreach (HtmlNode contentNode in debrisNodes)
                    {
                        string content = Regex.Match(contentNode.InnerText, @"^.*: (.*)$").Groups[1].Value;
                        content = content.Replace(".", "");
                        contentList.Add(Convert.ToInt32(content));
                    }
                    if (contentList[0] >= minRes || contentList[1] >= minRes)
                    {
                        debrisFields.Add(new DFCoordinates(debrisPosNode.InnerText, contentList[0], contentList[1], contentList[2]));
                    }
                }
            }
            return debrisFields;
        }

        public List<FleetMove> getFleetMove(Stream htmlStream)
        {
            List<FleetMove> fleetMoveList = new List<FleetMove>();
            HtmlNode rootNode = getDocumentNode(htmlStream);
            try
            {
                HtmlNodeCollection nodeCollection = rootNode.SelectNodes("//div[@id='eventListWrap']/table[@id='eventContent']/tbody/tr[contains(@id, 'eventRow-') or contains(@class, 'allianceAttack')]");
                if (nodeCollection != null)
                {
                    foreach (HtmlNode node in nodeCollection)
                    {
                        var fleetMove = new FleetMove();
                        fleetMove.Mission = (MissionType)node.GetAttributeValue("data-mission-type", 0);
                        fleetMove.FleetReturns = node.GetAttributeValue("data-return-flight", true);
                        fleetMove.ArrivalTime = DateTimeUtils.UnixTimeStampToDateTime(node.GetAttributeValue("data-arrival-time", 0));
                        var originFleetNode = node.SelectSingleNode(".//td[contains(@class, 'originFleet')]");
                        var originPlayerNode = node.SelectSingleNode(".//a[contains(@class, 'js_openChat')]");
                        fleetMove.OriginPlayer = originPlayerNode != null ? originPlayerNode.GetAttributeValue("title", "") : originFleetNode.InnerText.Trim();
                        fleetMove.IsEnemy = originPlayerNode != null;
                        fleetMove.Origin = new Coordinates(node.SelectSingleNode(".//td[contains(@class, 'coordsOrigin')]/a").InnerText.Trim());
                        fleetMove.Fleet = int.Parse(node.SelectSingleNode(".//td[contains(@class, 'detailsFleet')]/span").InnerText.Trim().Replace(".", ""));
                        fleetMove.TargetPlanet = node.SelectSingleNode(".//td[contains(@class, 'destFleet')]").InnerText.Trim();
                        fleetMove.Target = new Coordinates(node.SelectSingleNode(".//td[contains(@class, 'destCoords')]/a").InnerText.Trim());
                        fleetMoveList.Add(fleetMove);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("HTMLParserManager.getFleetMove: " + ex);
                logger.Error(ex.ToString());
            }
            return fleetMoveList;
        }
    }
}
