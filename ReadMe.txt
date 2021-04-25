>> OGame Empty Planet Finder <<
  Copyright (C) 2013-2015 applusplus

OGame EPF = OGame Empty Planet Finder
DF = Debris Field (german: TF = Trümmerfeld)

Changelog:
v0.6:
	- added: Browser for the currect ogame session.
	- added: Auto refresh interval in minutes.
	- added: Alert System 
	- added: Tray Icon with menu. It is available to hide the tool in the tray and instant close it from there.
	
v0.5:
	- fixed: "Copy List" buttons can be used again.
	- added: auto relogging function if the connection was closed.
	- added: informations, autorefresh CheckBox.
	- added: error logging
v0.4:
	- added: Multi OGame Homepages support
	- added: TabControl for mor search options
	- added: with radio buttons you can choose what are you looking for
	- added: Button for copying Debris list to the clipboard (insert with Ctrl+V)
	- added: possibility to choose your current planet for galaxy scanning
v0.3:
	- added: EPF now looking for Debris Fields too.
v0.2:
	- added: Search Engine status.
	- added: seaching now for destroyed plantes too.
	- added: Settings
	- removed: Splash-Screen during searching.
v0.1:
	- Version release as 0.1.
	- Now updating the Planetlist during the searching
	- Planetlist showing now only the full Coordinates.
	- Search Engine bringing now better error messages.

<How to use>

German:
>>>>>>>Grundlagen:
1. Sich unbedingt bei OGame ausloggen, falls ihr gerade spielt.
2. Rechts-Klick auf die "OGame Empty Planet Finder.exe" und "Als Administrator ausführen",
	auf das Fenster warten in dem gefragt wird welches Ogame ihr spielt.
3. Im Fenster eure OGame Homepage auswählen, beim deutschen OGame ist es "www.ogame.de".
4. Ein Splashscreen kommt, wartet auf das Login-Fenster.
5. Falls es zu einen Fehler kommt, schaut unten in den "Möglichen Fehler"-Abschnitt rein.
	Ansonsten fahrt mit Punkt 4 fort.
6. Wählt aus der Liste euren Server aus, z.B. "Orion".
	Gibt euren normalen OGame-Login ein und drückt "Login"-Button.
7. Falls der Login erfolgreich war, erscheint das eigentliche Suchfenster.
	Ab jetzt dürft ihr euch bei OGame nicht einloggen bis ihr mit der Suche fertig seid.
	Ansonsten wird die Session überschieben und der OGame Empty Planet Finder wird nicht mehr eingeloggt sein,
	was dazu führen kann, dass es nicht mehr richtig funktioniert.
8. Jetzt könnt ihr nach freien Planeten Suchen:
	1. Stellt den Radius(Search Range) ein in dem gesucht werden soll.
		Dabei müsst ihr beachten, dass das Sonnensystemradius für alle Galaxien gilt.
		Also wenn ihr Galaxie 1-3 einstellt und SunSys von 1-100, wird in jeder Galaxie
		nur die Sonnensysteme 1-100 gesucht.
	2. Drückt auf den Button "Search".
		An diese Stelle erscheint der Ladebildschirm.
		Die Suche kann je nach der Einstellung und Internetverbindung eine sehr lange Zeit in Anspruch nehmen.
		Falls ihr alle Galaxien 1-9 durchsucht und dabei alle Sonnensysteme 1-499 auswählt, könnte es bis zu 2 Stunden dauern.
		Deshalb sucht am besten mehrmals, kleinere Bereiche ab.
	Achtung! Während der Suche sollt ihr euch bei Ogame nicht anmelden.
9. Nach dem die Suche abgeschlossen ist, 
   könnt ihr mit dem Button "Copy Planets List to Clipboard" alle Planeten mit
   den OGame Koordinaten-Tags in die Zwischenablage kopieren und dann irgendwo mit Strg+V einfügen.
10. Es wird automatisch in den angegebenen Galaxien und Sonnensystemen auch nach Trümmerfeldern(DF(englisch Debris Field)) gesucht,
   dabei werden die angegebenen Mindestressourcen dafür verwendet. Also falls man z.B. 5000 eintippt,
   werden alle TF mit Metall oder Kristall gesucht bei denen eins von beiden größer als 5000 ist.
11. Falls es Fehlern auftretten, Fragen oder Verbessrungsvorschlägen gibts, kontaktiert mich.

>>>>>>>Weitere Features:
- Alarmsystem:
	Das Alarmsystem funktioniert am besten zusammen mit der Autorefresh-Funktion!
	Falls die Autorefresh-Funktion ausgeschaltet ist, wird dann nachgeprüft, wenn man selbst einen refresh druchführt
	oder automatisch, während der Planetensuche.
	Wie zu bedienen:
	1. Unter den Tab "Planet", könnt ihr "Auto Refresh" einschalten, in dem ihr ein Häkchen in die Checkbox setzt.
		Die eingegebene Zeit ist in Minuten, ich empfehle nicht mehr als 5 einzustellen, weil sonst könnte es zu spät sein, falls jemand
		aus der Nachbarschaft angreift. Weil die Informationen nur in diese Zeit aktualisiert und geprüft wird ob jemand angreift.
	2. Falls man angegriffen wird, wird automatisch der Tab "Alert" angezeigt.
		Dort wird angezeigt welche Fleet gerade angreift. Dabei wird die Zeile farbig markiert.
		Bei Rot dauert es weniger als 5min bis die angreifende Flotte den Planeten erreicht, bei Orange weniger als 10 und bei Gelb
		alles was länger dauert.
	3. Alarm Sound:
		Unter dem Tab "Alert" findet ihr ein Eingabefeld, eine Checkbox und zwei Buttons.
		1. Checkbox "Alert" aktiviert und deaktiviert den Alarmsound. Falls es dort ein Haken gesetzt wird, wird im Falle
			eines Angriffs eine zufällige Audiodatei aus dem eingestellten Ordner abgespielt bis man mit dem Button "Stop" es unterbricht.
		2. Standard Ordner mit den Sounds ist der Unterordner "data" der sich in dem selben Ordner wie die EPF exe befindet.
			Ihr könnt den Pfad zu den Sounds-Ordner auch selbst eingeben oder per drücken auf den "..."-Button auswählen.
		3. Mit "Test Sounds"-Button, könnt ihr testen wie die Sounds in dem Ordner abgespielt werden,
			falls es sich dort keine mp3 oder wav Dateien befinden, wird nichts passieren.
		4. Es können nur mp3 und wav Audioformate abgespielt werden!
- In Tray verstecken:
	Seit v0.6 ist es möglich das Fenster in die Tray-Leiste zu verstecken.
	1. Tray-Leiste sind die Icons rechts neben der Windows-Uhr.
	2. Macht dort einen Rechtsklick auf den EPF Icon, es öffnet sich ein Menü.
	3. Wählt "Hide" aus um das Fenster zu verstecken, genau so könnt ihr es wieder sichtbar machen.
	
>> Möglichen Fehler >>
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
1. Falls beim Login-Fenster ein Fehler auftritt, heißt es meistens, dass der OGame EPF, den OGame-Server nicht erreichen kann.
Es könnte sich um Internetproblemen handeln oder um einen Proxy oder um eine falsch ausgewählte Homepage. Falls man weiß, 
dass ein Proxy eingetragen werden muss, kann man es unter Button "Proxy", den Host und den Port eintragen und danach nochmal versuchen zu verbinden.
Ansonsten am besten neustarten und nochmal sicher gehen, dass man die Richtige Homepage (z.B. www.ogame.de) ausgewählt hat.
>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
2. (Kommt noch)