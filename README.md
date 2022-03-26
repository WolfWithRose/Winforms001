# Winforms001

A projekt neve: Vezetéknevek

Feladatleírás: 	Egy olyan program megalkotása volt a cél, amely egy adott populációt szimulál le,
				hogy hogyan szaporodnak az agensek, számosodnak az egy családban élők és hogy vezetéknév marad fenn legtovább.

Működése: 		Az agenseket egy pictureboxon jelenítettem meg a nőket piros, a férfiakat kék körökként. Ők amikor megszületnek random irányba, random sebességgel
				fognak elindulni. A falakról minden esetben visszapattannak, valamint az azonos neműek is lepattannak egymásról. Viszont, ha két különböző nemű
				agens találkozik és már mindkettő betöltötte a 18. életévét (ezt ugyanis számolja a program), akkor összeházasodnak és "letelepednek", vagyis a
				sebességvektoruk (0, 0) lesz, helyükön pedig egyetlen, kicsit nagyobb, lila kör keletkezik. Ez jelzi a kapcsolatukat. Ezeket az új lila köröket
				a többiek teljesen figyelmen kíül hagyják, nincsenek is rája hatással és egy kapcsolat ideális, azaz halálig tart. A lila körökből random idő-
				közönként (1-7 év) új agensek fognak születni és indulnak el a saját útjukon. Mikor pedig a pár egyik tagja eltávozik, a lila kör is megszűnik
				és a másik tag pedig újra elmegy kapcsolatot találni, igaz ezúttal kevesebb idővel. Nők 51-87 évet élnek míg a férfiak csak 49-82-t.

Használat:		A jobb oldalon állíthatjuk be milyen vezetéknevet vegyen föl az új agens és hogy mi legyen a neme. Ha ezt letudtuk már csak rá kell kattintanunk
				a fekete képernyőre, hogy hozzáadjuk az új egyént. Ezt annyiszor megismételhetjük amennyiszer szeretnénk. Ezután pedig a START gomb megnyomásával
				elindíthatjuk a szimulációt. Új agenseket szimuláció közben is hozzáadhatunk az előző módszerrel, de bármikor meg is tudjuk állítani a folyamatot
				a STOP gomb megnyomásával. A CLEAR gomb segítségével pedig törölhetünk minden agenst és elölről kezdhetjük a procedúrát. Mindezen kívül a jobb oldalt
				láthatjuk a szimuláció megkezdése óta eltelt éveket, a születések és halálozások számát, valamint az egyes családok számosságát.