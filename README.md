
##Reflektionsfrågor
### Trafikinformation
### http://trafikinformation.azurewebsites.net

#####Vad finns det för krav du måste anpassa dig efter i de olika API:erna?
Google Maps API som jag använder i min applikation kräver inte något nyckel eller token, och därför är lätt att förbi alla anpassningar.
Sverige radio API har _copyrights_ men information är fri att använda och har _fair use policy_ d.v.s. inga anropar i onödan, eller överanvändning av tjänsten.
#####Hur och hur länga cachar du ditt data för att slippa anropa API:erna i onödan?
Jag sparar information från Sverige Radio API i JSON fil. När min model skickar information till controller, först kontrollerar koden om det finns information i JSON fil och om timestamp som finns i filen är fortfarande gilgtig.
Jag tog beslut att casha information i 10 minuter. Om _timestamp_ + 10 minuter är mindre än aktuella tiden, då uppdateras information från Webb API, annars läser koden information från JSON fil.
Själva JSON filen har två egenskaper, copyright och messages. Messages konverterar jag till en lista med meddelanden, tills i copyright egenskap sparar jag timestamp.
På så sätt optimerar jag koden (använder egenskap som inte behövs i JSON fil, för att spara tidsinformation).
#####Vad finns det för risker kring säkerhet och stabilitet i din applikation?
Stabilitet beror helt på hur stabila information får jag från API:er. Om en av API:erna bytar data format finns risk att applikation kan sluta fungera. Alla javascript och css kod finns i separata filar, och slutliga användare kan inte mata information på något sätt.
I stort sätt beror säkerhet på själva API:er. En av saker som inte är bra är att man kan se inehållet av JSON fil på klienten, men den information är offentligt.
#####Hur har du tänkt kring säkerheten i din applikation?
I princip finns inga känsliga data i själva applikation, och finns inget som slutliga användare matar in (förutom att hen kan välja en kategori från dropdown list) vilket förenklar läge kraftigt runt säkerhet i applikation.

#####Hur har du tänkt kring optimeringen i din applikation?
Mina skripter laddas på slutet av Index dokument. Finns nästan inget redudant kod. Jag anropar inte API:er i onödan och cashar information så att det blir lite bättre prestanda.
Jag använde egenskap i själva API som jag inte behöver (copyright) för att spara timestamp (information om tiden när hämtas data från API) i den. På så sätt min JSON fil blir lite mindre i jämförelse om jag skapade en ny egenskap i den.
Nackdelen är att koden blev lite mindre läsbart (timestamp i copyright?).
