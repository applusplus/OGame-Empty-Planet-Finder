using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using NLog;
using OGameEmptyPlanetFinder.Exceptions;
using OGameEmptyPlanetFinder.HTML;
using OGameEmptyPlanetFinder.HTTP.JsonEntities;
using OGameEmptyPlanetFinder.HTTP.JsonEntities.GameAccount;
using OGameEmptyPlanetFinder.HTTP.JsonEntities.LoginEntities;
using OGameEmptyPlanetFinder.OGame;
using OGameEmptyPlanetFinder.OGame.Exceptions;
using OGameEmptyPlanetFinder.Settings;
using Server = OGameEmptyPlanetFinder.HTTP.JsonEntities.ServerEntities.Server;

namespace OGameEmptyPlanetFinder.HTTP
{
    public class HTTPConnectionManager
    {
        public static class RequestConst
        {
            public static readonly string GET = "GET";
            public static readonly string POST = "POST";
            public static readonly string MEDIA_TYPE = "HTTP/1.1";
            public static readonly string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:67.0) Gecko/20100101 Firefox/67.0";
            public static readonly string ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            public static readonly string CONTENT_TYPE_HTML = "text/html; charset=utf-8";
            public static readonly string CONTENT_TYPE_APPLICATION = "application/x-www-form-urlencoded";
            public static readonly string CONTENT_TYPE_JSON = "application/json;charset=utf-8";
            public static readonly int TIMEOUT = 60 * 1000;
        }

        // Login https://lobby.ogame.gameforge.com/api/users
        // Json: {"credentials":{"email":"applusplus@yahoo.de","password":"xyz"},"language":"de","kid":"","autoLogin":true}
        // Response: {"migrationRequired":false,"autoLoginToken":"a0153cb4-2440-4df0-9ad0-78105ebc41de"}

        // Next request: https://lobby.ogame.gameforge.com/api/users/me
        // Response {"id":324497,"userId":324497,"gameforgeAccountId":"da944aed-e39d-46de-83bd-ab05b055135a","validated":true,"portable":true,"unlinkedAccounts":false,"migrationRequired":false,"email":"applusplus@yahoo.de","unportableName":"applusplus"}
        // If not logged in
        // Code 403 Forbidden
        // {"error":"not logged in"}

        // If not logged in:
        // Lobby https://lobby.ogame.gameforge.com/api/login/lobby
        // token is probebly the autoLoginToken from Login request
        // POST Json: {"language":"de","token":"14e63a6a-c003-4df7-a70d-894d3b8dc8f9","kid":""}
        // Response: []
        // Code 200
        // After that the user should be logged in

        // Server list
        // GET https://lobby.ogame.gameforge.com/api/servers

        // List of all current playing game accounts for the gameforge user
        // GET https://lobby.ogame.gameforge.com/api/users/me/accounts
        // Response: [{"server":{"language":"en","number":160},"id":104830,"gameAccountId":104830,"name":"Director Dorado","lastPlayed":"2019-06-22T05:57:08+0100","lastLogin":"2019-06-22T04:57:08+0000","blocked":false,"bannedUntil":null,"bannedReason":null,"details":[{"type":"literal","title":"myAccounts.rank","value":"2152"},{"type":"localized","title":"myAccounts.status","value":"playerStatus.active"}],"sitting":{"shared":false,"endTime":null,"cooldownTime":null},"trading":{"trading":false,"cooldownTime":null}},{"server":{"language":"de","number":160},"id":109053,"gameAccountId":109053,"name":"Procurator Alpha","lastPlayed":"2019-06-18T15:28:29+0200","lastLogin":"2019-06-18T13:28:29+0000","blocked":false,"bannedUntil":null,"bannedReason":null,"details":[{"type":"literal","title":"myAccounts.rank","value":"2222"},{"type":"localized","title":"myAccounts.status","value":"playerStatus.active"}],"sitting":{"shared":false,"endTime":null,"cooldownTime":null},"trading":{"trading":false,"cooldownTime":null}},{"server":{"language":"de","number":161},"id":109904,"gameAccountId":109904,"name":"applusplus","lastPlayed":"2019-06-24T15:41:38+0000","lastLogin":"2019-06-24T15:41:38+0000","blocked":false,"bannedUntil":null,"bannedReason":null,"details":[{"type":"literal","title":"myAccounts.rank","value":"2450"},{"type":"localized","title":"myAccounts.status","value":"playerStatus.active"}],"sitting":{"shared":false,"endTime":null,"cooldownTime":null},"trading":{"trading":false,"cooldownTime":null}},{"server":{"language":"de","number":159},"id":112096,"gameAccountId":112096,"name":"Captain Taurus","lastPlayed":"2019-06-18T15:27:52+0200","lastLogin":"2019-06-18T13:27:51+0000","blocked":false,"bannedUntil":null,"bannedReason":null,"details":[{"type":"literal","title":"myAccounts.rank","value":"3156"},{"type":"localized","title":"myAccounts.status","value":"playerStatus.active"}],"sitting":{"shared":false,"endTime":null,"cooldownTime":null},"trading":{"trading":false,"cooldownTime":null}},{"server":{"language":"de","number":146},"id":112111,"gameAccountId":112111,"name":"applusplus","lastPlayed":"2016-08-09T18:25:36+0200","lastLogin":"2018-10-29T10:04:46+0000","blocked":false,"bannedUntil":null,"bannedReason":null,"details":[{"type":"literal","title":"myAccounts.rank","value":"1494"},{"type":"localized","title":"myAccounts.status","value":"playerStatus.vacation"}],"sitting":{"shared":false,"endTime":null,"cooldownTime":null},"trading":{"trading":false,"cooldownTime":null}},{"server":{"language":"de","number":115},"id":143362,"gameAccountId":143362,"name":"applusplus","lastPlayed":"2018-10-29T20:03:06+0100","lastLogin":"2018-10-29T19:03:05+0000","blocked":false,"bannedUntil":null,"bannedReason":null,"details":[{"type":"literal","title":"myAccounts.rank","value":"2858"},{"type":"localized","title":"myAccounts.status","value":"playerStatus.vacation"}],"sitting":{"shared":false,"endTime":null,"cooldownTime":null},"trading":{"trading":false,"cooldownTime":null}}]

        // If you click on "Last played" button in the "lobby"
        // https://lobby.ogame.gameforge.com/api/users/me/loginLink?id=109904&server[language]=de&server[number]=161
        // Response: {"url":"https:\/\/s161-de.ogame.gameforge.com\/game\/lobbylogin.php?id=109904&token=7710e362-9b67-4f1d-b1b5-cb58204161db"}
        // Should try to use this link to get in

        private static readonly string ACCOUNT_BASE_URL = "https://lobby.ogame.gameforge.com";
        private static readonly string REDIRECT_HOME_URL = ACCOUNT_BASE_URL + "/?language={0}"; // https://lobby.ogame.gameforge.com/?language=de
        private static readonly string GET_SERVERS_URL = ACCOUNT_BASE_URL + "/api/servers"; // https://lobby.ogame.gameforge.com/api/servers
        private static readonly string LOGIN_URL = ACCOUNT_BASE_URL + "/api/users"; // https://lobby.ogame.gameforge.com/api/users
        private static readonly string USER_API_URL = LOGIN_URL + "/me"; // https://lobby.ogame.gameforge.com/api/users/me
        private static readonly string GET_ACCOUNTS_URL = USER_API_URL + "/accounts"; // https://lobby.ogame.gameforge.com/api/users/me/accounts
        private static readonly string LOBBY_LOGIN_URL = USER_API_URL + "/loginLink?id={0}&server[language]={1}&server[number]={2}"; // 0 = game account id, 1 = language, 2 = Uni number
        //private static readonly string LOGIN_LOBBY_URL = GET_SERVERS_URL + "/api/login/lobby"; // https://lobby.ogame.gameforge.com/api/login/lobby
        private static readonly string GAME_BASE_URL = "https://s{0}-{1}.ogame.gameforge.com/game/index.php"; //0 = server number, 1 = langauge e.g.: https://s{0}-{1}.ogame.gameforge.com/game/index.php



        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static HTTPConnectionManager instance;
        private static readonly object syncRoot = new Object();
        // Lazy Singleton
        public static HTTPConnectionManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new HTTPConnectionManager();
                    }
                }
                return instance;
            }
        }

        private bool _isRunning;
        private bool IsRunning
        {
            get
            {
                lock (syncRoot)
                {
                    return _isRunning;
                }
            }
            set
            {
                lock (syncRoot)
                {
                    _isRunning = value;
                }
            }
        }

        private readonly HTMLParserManager htmlParserManager;

        private CookieContainer cookieContainer;

        private WebProxy _proxy;

        public WebProxy Proxy
        {
            get
            {
                if(SettingsService.Instance.Settings.Proxy == null)
                {
                    _proxy = null;
                }
                else if (_proxy == null && SettingsService.Instance.Settings.Proxy != null && !string.IsNullOrEmpty(SettingsService.Instance.Settings.Proxy.Host))
                {
                    _proxy = new WebProxy(SettingsService.Instance.Settings.Proxy.Host, SettingsService.Instance.Settings.Proxy.Port);
                }

                return _proxy;
            }
        }

        private HTTPConnectionManager()
        {
            htmlParserManager = new HTMLParserManager();
            IsRunning = true;
            ResetCookieContainer();
        }

        private void ResetCookieContainer()
        {
            cookieContainer = new CookieContainer();
        }

        public List<Server> RequestServers()
        {
            var list = new List<Server>();
            HttpWebResponse htmlResponse = null;
            StreamReader streamReader = null;
            JsonReader jsonReader = null;
            try
            {
                var httpWebRequest = createDefaultWebRequest(GET_SERVERS_URL, RequestConst.GET);
                htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(htmlResponse.GetResponseStream());
                jsonReader = new JsonTextReader(streamReader);
                var serializer = new JsonSerializer();
                list = serializer.Deserialize<List<Server>>(jsonReader);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "RequestServers failed");
            }
            finally
            {
                htmlResponse?.Close();
                streamReader?.Close();
                jsonReader?.Close();
            }
            return list;
        }

        public bool RequestLogin(string email, string password)
        {
            var isSuccess = false;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var credentials = new Credentials
                {
                    email = email,
                    password = password
                };
                var login = new Login
                {
                    credentials = credentials,
                    language = SettingsService.Instance.Settings.ServerLanguage,
                    kid = "",
                    autoLogin = true
                };

                var loginJson = JsonConvert.SerializeObject(login);
                byte[] outputData = new UTF8Encoding().GetBytes(loginJson);
                var httpWebRequest = createDefaultWebRequest(LOGIN_URL, RequestConst.POST, outputData);
                HttpWebResponse htmlResponse = null;
                try
                {
                    htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (htmlResponse.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        using (StreamReader sr = new StreamReader(htmlResponse.GetResponseStream()))
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            var serializer = new JsonSerializer();
                            var loginResponse = serializer.Deserialize<LoginResponseEntity>(reader);
                        }
                    }
                    else
                    {
                        throw new LoginException("Incorrect Login Informations, please check you server, login and password!");
                    }
                    isSuccess = CheckLogin() != null;
                }
                catch (LoginException ex)
                {
                    throw ex;
                }
                catch (WebException ex)
                {
                    throw new LoginException("Incorrect Login Informations, please check you server, login and password!");
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "loginRequest.HttpWebResponse");
                }
                finally
                {
                    htmlResponse?.Close();
                }
            }
            else
            {
                throw new LoginException("User or password is empty");
            }
            
            return isSuccess;
        }

        public GameAccountEntity GetAccountEntityByServerInfo(string language, int uniNumber)
        {
            GameAccountEntity result = null;
            HttpWebResponse htmlResponse = null;
            StreamReader streamReader = null;
            JsonReader jsonReader = null;
            try
            {
                var httpWebRequest = createDefaultWebRequest(GET_ACCOUNTS_URL, RequestConst.GET);
                htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                streamReader = new StreamReader(htmlResponse.GetResponseStream());
                jsonReader = new JsonTextReader(streamReader);
                var serializer = new JsonSerializer();
                var gameAccounts = serializer.Deserialize<List<GameAccountEntity>>(jsonReader);
                foreach (var gameAccount in gameAccounts)
                {
                    if (gameAccount.server.language.Equals(language) && gameAccount.server.number.Equals(uniNumber))
                    {
                        result = gameAccount;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "GetAccountEntityByServerInfo failed");
            }
            finally
            {
                htmlResponse?.Close();
                streamReader?.Close();
                jsonReader?.Close();
            }
            return result;
        }

        private bool RequestLobbyLogin(string url)
        {
            var result = false;
            HttpWebResponse htmlResponse = null;
            try
            {
                var httpWebRequest = createDefaultWebRequest(url, RequestConst.GET);
                httpWebRequest.ContentType = RequestConst.CONTENT_TYPE_JSON;
                htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (htmlResponse.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var responseStream = CopyAndCloseStream(htmlResponse.GetResponseStream());
                    if (responseStream != null)
                    {
                        htmlParserManager.fillPlayerInfoWithMetaData(responseStream);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "RequestServers failed");
            }
            finally
            {
                htmlResponse?.Close();
            }
            return result;
        }

        public bool LoginIntoGameAccount()
        {
            var result = false;
            var gameAccountEntity = GetAccountEntityByServerInfo(SettingsService.Instance.Settings.ServerLanguage, SettingsService.Instance.Settings.Login.UniNumber);
            if (gameAccountEntity != null)
            {
                HttpWebResponse htmlResponse = null;
                StreamReader streamReader = null;
                JsonReader jsonReader = null;
                try
                {
                    var httpWebRequest = createDefaultWebRequest(string.Format(LOBBY_LOGIN_URL, gameAccountEntity.gameAccountId, gameAccountEntity.server.language, gameAccountEntity.server.number), RequestConst.GET);
                    httpWebRequest.ContentType = RequestConst.CONTENT_TYPE_JSON;
                    htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    streamReader = new StreamReader(htmlResponse.GetResponseStream());
                    jsonReader = new JsonTextReader(streamReader);
                    var serializer = new JsonSerializer();
                    var urlOnlyEntity = serializer.Deserialize<UrlOnlyEntity>(jsonReader);
                    result = RequestLobbyLogin(urlOnlyEntity.url);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "RequestServers failed");
                }
                finally
                {
                    htmlResponse?.Close();
                    streamReader?.Close();
                    jsonReader?.Close();
                }
            }
            return result;
        }

        public bool RequestAndFillPlayerInfoWithMetaData()
        {
            var result = false;
            HttpWebResponse htmlResponse = null;
            try
            {
                var httpWebRequest = createDefaultWebRequest(string.Format(GAME_BASE_URL, SettingsService.Instance.Settings.Login.UniNumber, SettingsService.Instance.Settings.ServerLanguage), RequestConst.GET);
                htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var responseStream = CopyAndCloseStream(htmlResponse.GetResponseStream());
                if (responseStream != null)
                {
                    htmlParserManager.fillPlayerInfoWithMetaData(responseStream);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "RequestAndFillPlayerInfoWithMetaData error");
            }
            finally
            {
                htmlResponse?.Close();
            }
            return result;
        }

        public string getPageUrl(string page = "", bool ajax = false)
        {
            var sb = new StringBuilder(string.Format(GAME_BASE_URL, SettingsService.Instance.Settings.Login.UniNumber, SettingsService.Instance.Settings.ServerLanguage) + "?page=");
            if (!string.IsNullOrEmpty(page))
            {
                sb.Append(page);
                if (ajax)
                {
                    sb.Append("&ajax=1");
                }
            }
            return sb.ToString();
        }

        public string getPlanetUrl(string planetId = "", string page = "galaxy")
        {
            var result = new StringBuilder(getPageUrl(page));
            if (!string.IsNullOrEmpty(planetId))
            {
                result.Append("&cp=" + planetId);
            }
            return result.ToString();
        }

        public NavigationResult NavigationRequest(string planetId = "", string page = "galaxy")
        {
            var navigationResult = NavigationResult.Failed;
            var galaxyOverview = getPlanetUrl(planetId, page);
            HttpWebResponse htmlResponse = null;
            Stream responseStream = null;
            try
            {
                if (SendRequestAndRepeatIfFailed(ref htmlResponse, galaxyOverview, RequestConst.GET))
                {
                    responseStream = CopyAndCloseStream(htmlResponse.GetResponseStream());
                    htmlParserManager.fillPlayerInfoWithMetaData(responseStream);
                    if (htmlParserManager.isAlertVisible(responseStream))
                    {
                        navigationResult = NavigationResult.UnderAttack;
                    }
                    else
                    {
                        navigationResult = NavigationResult.Success;
                    }
                }
                else
                {
                    throw new SessionClosedException("Couldn't redo the NavigationRequest");
                }
                
            }
            catch (SessionClosedException ex)
            {
                navigationResult = NavigationResult.Failed;
                Logger.Info(ex);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "refreshRequest.HttpWebResponse failed");
            }
            finally
            {
                htmlResponse?.Close();
                responseStream?.Close();
            }
            return navigationResult;
        }

        public int CheckFleetMoving()
        {
            var fleetInMove = 0;
            var eventListUrl = getPageUrl("eventList", true);
            HttpWebResponse htmlResponse = null;
            Stream responseStream = null;
            try
            {
                if (SendRequestAndRepeatIfFailed(ref htmlResponse, eventListUrl, RequestConst.GET))
                {
                    responseStream = CopyAndCloseStream(htmlResponse.GetResponseStream());
                    PlayerInfo.Instance.FleetMove = htmlParserManager.getFleetMove(responseStream);
                    fleetInMove = PlayerInfo.Instance.FleetMove.Count;
                }
                else
                {
                    throw new SessionClosedException("Couldn't redo the CheckFleetMoving request");
                }
               
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "CheckFleetMoving failed");
            }
            finally
            {
                htmlResponse?.Close();
                responseStream?.Close();
            }
            return fleetInMove;
        }

        public Exception SearchEmptyPlanets(Coordinates[] coordinates, ListView listFreePlanets, ListView listDF, int minDFRes, Label labStatus, SearchChoise choisen)
        {
            Exception exception = null;
            List<Coordinates> listPlanets;
            NavigationResult navigationResult = NavigationRequest();
            if (NavigationResult.Success.Equals(navigationResult))
            {
                Random random = new Random();
                listPlanets = new List<Coordinates>();
                string galaxyContentUrl = getPageUrl("galaxyContent", true);
                for (int i = coordinates[0].Galaxy; i <= coordinates[1].Galaxy; i++)
                {
                    for (int j = coordinates[0].SunSys; j <= coordinates[1].SunSys; j++)
                    {
                        if (!IsRunning)
                        {
                            break;
                        }
                        var StringBuilder = new StringBuilder();
                        StringBuilder.Append("galaxy=").Append(i);
                        StringBuilder.Append("&system=").Append(j);
                        var outputData = new UTF8Encoding().GetBytes(StringBuilder.ToString());

                        HttpWebResponse htmlResponse = null;
                        Stream responseStream = null;
                        try
                        {
                            var sbStatus = new StringBuilder();
                            sbStatus.Append(i).Append(":").Append(j).Append(":xx");
                            if (labStatus.InvokeRequired)
                            {
                                labStatus.BeginInvoke(new MethodInvoker(() => labStatus.Text = sbStatus.ToString()));
                            }
                            else
                            {
                                labStatus.Text = sbStatus.ToString();
                            }
                            if (SendRequestAndRepeatIfFailed(ref htmlResponse, galaxyContentUrl, RequestConst.POST, outputData))
                            {
                                responseStream = CopyAndCloseStream(htmlResponse.GetResponseStream());
                                if (choisen.Equals(SearchChoise.EmptyPlanet) || choisen.Equals(SearchChoise.All))
                                {
                                    List<Coordinates> emptyPlanets = htmlParserManager.getEmptyPlanets(responseStream, i, j, coordinates[0].Planet, coordinates[1].Planet);
                                    listPlanets.AddRange(emptyPlanets);
                                    foreach (Coordinates coords in emptyPlanets)
                                    {
                                        ListViewItem listViewItem = new ListViewItem(new[] { coords.ToString(), coords.getStatus() });
                                        if (listFreePlanets.InvokeRequired)
                                        {
                                            listFreePlanets.BeginInvoke(new MethodInvoker(() => listFreePlanets.Items.Add(listViewItem)));
                                        }
                                        else
                                        {
                                            listFreePlanets.Items.Add(listViewItem);
                                        }
                                    }
                                }
                                if (choisen.Equals(SearchChoise.Debris) || choisen.Equals(SearchChoise.All))
                                {
                                    List<DFCoordinates> debrisFields = htmlParserManager.getDebrisFields(responseStream, minDFRes);
                                    foreach (DFCoordinates coords in debrisFields)
                                    {
                                        ListViewItem listViewItem = new ListViewItem(new[] { coords.ToString(),
                                            $"{coords.Metal.ToString():0,0}", $"{coords.Crystal.ToString():0,0}",
                                            $"{coords.Recyclers.ToString():0,0}"
                                        });
                                        if (listDF.InvokeRequired)
                                        {
                                            listDF.BeginInvoke(new MethodInvoker(() => listDF.Items.Add(listViewItem)));
                                        }
                                        else
                                        {
                                            listDF.Items.Add(listViewItem);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new SessionClosedException($"Couldn't redo SearchEmptyPlanets request {sbStatus}");
                            }
                            
                        }
                        catch (SessionClosedException ex)
                        {
                            IsRunning = false;
                            exception = ex;
                            Logger.Warn(ex, "searchEmptyPlanets.HttpWebResponse failed");
                        }
                        catch (Exception ex)
                        {
                            IsRunning = false;
                            exception = new Exception("Error during the searching");
                            Logger.Error(ex);
                        }
                        finally
                        {
                            htmlResponse?.Close();
                            responseStream?.Close();
                        }
                        secondsSleep(random.Next(1, 5));
                    }
                    if (!IsRunning)
                    {
                        if (exception == null)
                        {
                            exception = new Exception("Search canceled");
                        }
                        break;
                    }
                    secondsSleep(random.Next(1, 10));
                }
            }
            else if (NavigationResult.UnderAttack.Equals(navigationResult))
            {
                exception = new UnderAttackException("Enemies fleet is incoming!");
            }
            else
            {
                exception = new SessionClosedException("The Session was closed by the server, please try again.");
            }
            IsRunning = true;
            return exception;
        }

        private void secondsSleep(int seconds)
        {
            for (var t = 1; t <= seconds; t++)
            {
                if (!IsRunning)
                {
                    break;
                }
                Thread.Sleep(100);
            }
        }

        public void StopThread()
        {
            IsRunning = false;
        }

        public UserEntity CheckLogin()
        {
            UserEntity result = null;
            HttpWebResponse htmlResponse = null;
            StreamReader streamReader = null;
            JsonReader jsonReader = null;
            try
            {
                var httpWebRequest = createDefaultWebRequest(USER_API_URL, RequestConst.GET);
                htmlResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                if (htmlResponse.StatusCode.Equals(HttpStatusCode.OK))
                {
                    streamReader = new StreamReader(htmlResponse.GetResponseStream());
                    jsonReader = new JsonTextReader(streamReader);
                    var serializer = new JsonSerializer();
                    result = serializer.Deserialize<UserEntity>(jsonReader);
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, "CheckLogin error");
            }
            finally
            {
                htmlResponse?.Close();
                streamReader?.Close();
                jsonReader?.Close();
            }
            return result;
        }

        public bool CheckLoginAndRefresh()
        {
            var result = CheckLogin() != null;
            if (!result)
            {
                ResetCookieContainer();
                if (RequestLogin(SettingsService.Instance.Settings.Login.Email,
                    SettingsService.Instance.Settings.Login.CryptPassword))
                {
                    result = LoginIntoGameAccount();
                }
            }
            return result;
        }

        public void logout()
        {
            HttpWebResponse htmlResponse = null;
            try
            {
                string logout = getPageUrl("logout");
                HttpWebRequest httpWebRequest = createDefaultWebRequest(logout, RequestConst.GET);
                htmlResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "logout error");
            }
            finally
            {
                htmlResponse?.Close();
            }
        }

        private HttpWebRequest createDefaultWebRequest(string url, string method, byte[] inputData = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = method;
            httpWebRequest.MediaType = RequestConst.MEDIA_TYPE;
            httpWebRequest.UserAgent = RequestConst.USER_AGENT;
            httpWebRequest.Accept = RequestConst.ACCEPT;
            httpWebRequest.ContentType = method.Equals(RequestConst.GET) ? RequestConst.CONTENT_TYPE_HTML : RequestConst.CONTENT_TYPE_JSON;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Timeout = RequestConst.TIMEOUT;
            httpWebRequest.AllowAutoRedirect = true;
            httpWebRequest.CookieContainer = cookieContainer;
            if (Proxy != null)
            {
                httpWebRequest.Proxy = Proxy;
            }
            if (method.Equals(RequestConst.POST) && inputData != null && inputData.Length > 0)
            {
                httpWebRequest.ContentLength = inputData.Length;
                using (var stream = httpWebRequest.GetRequestStream())
                {
                    stream.Write(inputData, 0, inputData.Length);
                }
            }

            return httpWebRequest;
        }

        public CookieCollection getCookieCollection(string url)
        {
            return cookieContainer.GetCookies(new Uri(url));
        }

        public void setCookies(Uri url, string cookiestring)
        {
            cookieContainer.SetCookies(url, cookiestring);
        }

        private bool SendRequestAndRepeatIfFailed(ref HttpWebResponse responseRef, string url, string method, byte[] inputData = null)
        {
            var result = false;
            do
            {
                try
                {
                    var httpWebRequest = createDefaultWebRequest(url, method, inputData);
                    responseRef = (HttpWebResponse)httpWebRequest.GetResponse();
                    if (responseRef.StatusCode.Equals(HttpStatusCode.Found) || responseRef.ResponseUri.AbsoluteUri.Equals(string.Format(REDIRECT_HOME_URL, SettingsService.Instance.Settings.ServerLanguage)))
                    {
                        result = CheckLoginAndRefresh();
                        if (result)
                        {
                            throw new AccessViolationException("Redoing the request");
                        }
                    }
                    else if (responseRef.StatusCode.Equals(HttpStatusCode.OK))
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    responseRef?.Close();
                    responseRef = null;
                }
            } while (responseRef == null);

            return result;
        }

        private static Stream CopyAndCloseStream(Stream inputStream)
        {
            const int readSize = 256;
            byte[] buffer = new byte[readSize];
            MemoryStream ms = new MemoryStream();

            int count = inputStream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                ms.Write(buffer, 0, count);
                count = inputStream.Read(buffer, 0, readSize);
            }
            ms.Position = 0;
            inputStream.Close();
            return ms;
        }
    }

    public enum SearchChoise
    {
        All,
        EmptyPlanet,
        Debris
    }

    public enum NavigationResult
    {
        Failed,
        Success,
        UnderAttack
    }
}
