
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

##Uppdatering

#####CSRF

CSRF (eng. Cross-Site Request Forgery) är en attack i vilken elak användare utnyttjar användare som är inloggad på någon tjänst eller webbplats, genom att skicka HTTP Request som den inloggade användare. Elak användare utnyttjar att attackerade webbtjänst kollar inte från vilken källa kommer HTTP Request. Förutom att elak användare utnyttjar själva webbtjänst, vanlig användares webbläsare är också utnyttjad om den är inloggad på webbtjänst i frågan. Man kan förhindra CRSF attack genom att använda token i form av en session, som kan få ett nytt värde varje gång sidan laddas om. På så sätt kan vi se om det handlar om riktigt request. Andra möjliga sätt är att kräva om-autentisering av användare, eller vi kan gömma token i URLen.


#####Hashning och Kryptering - skillnad

######Kryptering
Kryptering är teknik för ändring av känsliga data under transfer tid innan datan lagras permanent. Det finns två olika typer av kryptering, symmetrisk och asymmetrisk Symmetrisk kryptering använder en  nyckel för kryptering av data, och samma nyckel för de-kryptering när data sparas. Asymmetrisk kryptering använder två nycklar, öppen och privat. Dom två nycklarna är matematiskt relaterade.
VIKTIGT: En gång när data krypteras, det ÄR möjligt med rätt nyckel att de-kryptera värdet igen.
Exempel på symmetrisk kryptering (en nyckel för kryptering och de-kryptering):
![symmetric-key-cyrptography](https://cloud.githubusercontent.com/assets/8629282/12337175/c3075fa8-bb08-11e5-8719-cfa28a6d6e50.jpg)
######Hashning
Hashning är teknik av förändring av input-sträng med hjälp av olika algoritmer eller hasning funktioner. Förändrad sträng lagras permanent i databas eller fil. Hasning-funktion är inverterbar. En gång när vi hashar lösenordet och sparar i databas, vi kan inte (eller bör inte) se den värdet som strängen hade i början.

######Skillnad
Hashning är en väg process, och lösenordet sparas som förändrad värde. Det är omöjligt (utan hackning) få det originella värdet igen.
Kryptering krypterar och de-krypterar data genom att använda en eller två nycklar. Det är möjligt att se det originella värdet.

######Hantering av hashning
Finns flera steg som man kan göra om man vill hasha lösenordet rätt:
* Använda säkrare och etablerade hashfunktioner, som PBKDF2, bcrypt och scrypt
* "Salta" lösenordet innan hasning. Det betyder att man tilläger ett slumpmäsigt värde till lösenord innan hashning. Saltet kan lagras i klar text, och viktigt är att saltet är uniket per användare (bra praktik är att det är tillräckligt långt).
Fördelar med salt är följande:
 * Rainbow tables attacker blir svårare
 * Två användare med samma lösenord för olika värden sparade i databas
* Uppmuntra användare att välja ett smart lösenord
 * Använda flera tecken som är inte bokstäver och siffror.
 * Använda INTE samma lösenord för flera tjänster
* Använd samma felmeddelande om angiven lösenord eller användarnamn är inte rätt (Man undviker bekräfta att angiven användarnamn är rätt).

#####Websockets
Websockets är avancerad teknik vilken öppnar en uppkoppling mellan webbläsare och server, och då uppkoppling finns den är tillgängligt tills servern eller klient avslutar den. Med öppen uppkoppling mellan servern och klient, webbläsaren och servern kan byta meddelande mellan varandra. Det gör webbutveckling _event driven_ , oberoende av användare.
Webscoket uppkoppling är som sagt _event driven_ , snabbt och två-väg. Innan websockets, allt trafik mellan klient och servern var på HTTP protokoll





