Videogioco creato con Unity e con l'utilizzo di C#


Spiegazione generale del progetto

Icona e Splash Screen

Ho creato una splash screen tramite Canva e scaricato una icona da internet, per poi inserirle attraverso i settaggi forniti da Unity.

Scopo del gioco

Lo scopo del gioco è quello di comandare un cavaliere (Agro) e di andare avanti nel dungeon per sconfiggere il boss. Lungo il tragitto si possono trovare delle monete raccoglibili e dei cuori che vanno a ripristinare un po' di salute se serve. Il gioco tiene traccia dei tentativi fatti (partite giocate, si resetta all’uscita del gioco), e di uno score che progredisce in base a quanti nemici vengono sconfitti. Il gioco presenta tre diverse difficoltà: Facile, Normale e Difficile (si andrà a variare la salute dei nemici, rendendo così il gioco più impegnativo in caso di difficoltà maggiore). Il gioco è in 2D con visuale isometrica.


Menu

Il mene del gioco presenta varie voci:
•	Nuova partita: permette di iniziare una nuova partita. Verremo portati in un’altra schermata, dove sarà possibile scegliere la difficoltà;
•	Opzioni: ci permette di regolare il volume della musica e di vedere i comandi del gioco;
•	Crediti: mostra i crediti del gioco;
•	Esci: ci porta fuori dal gioco.


HUD

L’HUD del gioco è composto da quattro parti:
•	Container dei cuori: si trova in alto a sinistra e indica quanta vita ha il nostro personaggio;
•	Contatore monete: si trova in basso a sinistra e indica quante monete sono state raccolte;
•	Numero di tentativi: si trova in alto a destra e indica quante partite sono state fatte in una sessione di gioco;
•	Score: si trova in basso a destra e indica il nostro punteggio.


Mappe

Le mappe sono state create con degli asset trovati online e con l’utilizzo di Tiled.


Oggetti raccoglibili/PowerUP

Abbiamo due tipi di oggetti raccoglibili:
•	Cuori: permettono di ripristinare una parte della nostra salute. Se la nostra salute è al massimo non sarà possibile raccoglierli, ma, se il nostro personaggio prendesse del danno in futuro, potrebbe sempre tornare indietro a raccoglierlo (il cuore rimane lì per tutta la durata del gioco);
•	Monete: possono essere raccolte e inserite in un inventario virtuale. Essendo una demo non ho implementato un vero e proprio utilizzo, ma, in un gioco completo, potrebbero essere utilizzate in un negozio, oppure, potrebbero essere un requisito per passare in un’altra area (Es: “Devi avere 50 monete per attraversare questo ponte”).


Score

Si aggiorna in base ai nemici che sconfiggiamo, ma, essendo una demo, è altamente probabile che ogni partita finisca sempre con lo stesso score (essendoci pochi nemici). In un gioco completo potrebbero essere inseriti dei nemici in punti nascosti e diversi tra loro (magari cambiando anche l’assegnazione dei punti in base al nemico).


Menu di pausa

Il menu di pausa (attivabile col tasto “escape”) ci permette di riprendere la partita o di tornare al menu principale del gioco.


Schermata di Game Over/Vittoria

Abbiamo due casi:
•	Sconfitta: se siamo in questo caso vuol dire che la salute del nostro personaggio è scesa fino a zero, e di conseguenza apparirà la schermata di “Game Over”, che ci permetterà di tornare al menu principale;
•	Vittoria: se siamo in questo caso vuol dire che abbiamo sconfitto il boss del gioco, e, di conseguenza, apparirà la schermata di “Vittoria” che ci permetterà di tornare al menu principale.


Salute dei nemici e difficoltà


La salute dei nemici viene inizializzata attraverso un “ScriptableObject” e modificata con uno script in base alla difficoltà. L’uso dello ScriptableObject permette in modo veloce di assegnare la stessa quantità di vita a nemici simili tra loro (ad esempio i nemici del primo mondo di un gioco potrebbero avere tutti la stessa vita, anche se sono visivamente diversi tra loro. Lo si può vedere come una salute di base). Abbiamo tre diverse difficoltà:
•	Facile: la salute iniziale dei nemici non sarà variata, ma viene mantenuta quella inserita nello ScriptableObject (in gioco si faccia riferimento a “EnemyHealth”);
•	Normale: la salute iniziale dei nemici viene aumentata del 50%;
•	Difficile: la salute iniziale  dei nemici viene aumentata del 100%.


Nemici


I nemici del gioco sono stati creati con degli asset trovati online, ma le animazioni sono state fatte da zero. La loro eliminazione sarà seguita da un’animazione di morte (“Death Effect” in gioco). I nemici sono gestiti dagli script ed è possibile gestire:
•	Vita: inserendo un valore in questo campo andremo ad incrementare il valore di EnemyHealth. Ho voluto fare questo sistema in modo da poter differenziare anche i nemici simili tra loro. Ad esempio, per il boss ho voluto riutilizzare lo stesso tipo di nemico (“Minion” in gioco), ma l’ho differenziato dagli altri attraverso il campo vita, dandogli quindi più salute;
•	Base ATT: indica quanto danno un nemico fa, ad ogni hit, al nostro personaggio;
•	Velocità: indica quanto veloce si muove il nemico;
•	Current State: attraverso la creazione di una macchina a stati finiti i nemici possono trovarsi in diversi stati, in base a se sono fermi, se stanno camminando, se stanno attaccando o se sono stati colpiti;
•	Death Effect: si può inserire un’animazione a piacere che comparirà all’eliminazione del nemico;
•	Is Boss: essendo una demo ho voluto riutilizzare lo stesso nemico anche per il boss. Con questa variabile faccio capire al gioco chi è il boss, in modo da far comparire la schermata di vittoria se viene eliminato;
•	Target: possiamo impostare cosa o chi il nemico deve attaccare;
•	Chase e Attack radius: indicano il raggio d’azione del nemico (inseguimento e attacco).


Personaggio


Il personaggio del gioco è stato creato con degli asset trovati online, ma le animazioni sono state fatte da zero. La sua eliminazione sarà seguita da un’animazione di morte (“Death Effect” in gioco). Il personaggio è gestito dagli script ed è possibile gestire:
•	Current State: come per i nemici, il personaggio può variare il suo stato attraverso una macchina a stati finiti, e presenta gli stessi stati dei nemici (idle, walk, attack e stagger);
•	Velocità: indica la velocità del nostro personaggio;
•	Current Health: indica la vita del nostro personaggio, anch’essa realizzata attraverso uno ScriptableObject (nel gioco “PlayerHealt”);
•	Knockback: possiamo decidere quanto danno fa il nostro personaggio, il lasso di tempo per il quale il nostro nemico si troverà nello stato di stagger, e quanto deve essere potente la spinta causata dal nostro attacco (N.B: ho voluto applicare il knockback anche al contatto con un nemico, e non solo all’attacco, perché l’ho voluto pensare come un attacco corpo a corpo con il quale colpisci il nemico, ma a discapito di perdere vita).


ScriptableObject


Gli ScriptableObject sono degli oggetti che possono essere facilmente riutilizzabili in più posti. I tipi che ho realizzato per questi oggetti sono:
•	FloatValue: è un tipo di oggetto che ha un valore iniziale e un valore “Runtime” che può essere modificato durante il corso del gioco (come la salute del nostro personaggio, ecc...);
•	Inventory: è un tipo di oggetto dove all’interno può contenere varie cose, oggetti, metodi add, remove e così via. Essendo una demo ho inserito solo il numero di monete. Usando l’inventario in questo modo è possibile darlo a più personaggi, senza dover creare ulteriori classi (lo si può vedere come uno “stampo”);
•	Signal Listener/Sender: implementano il design pattern Observer, permettendo di non far entrare a stretto contatto le classi tra loro (utile, ad esempio, quando vogliamo aggiornare la salute del nostro personaggio).
Di seguito gli ScriptableObject che ho realizzato:
•	EnemyHealth: è un FloatValue e indica la salute iniziale del nemico;
•	PlayerHealth: è un FloatValue e indica la salute iniziale del nostro personaggio;
•	HeartContainer: è un FloatValue e indica quanti cuori deve avere l’HUD della salute (ho inserito nell’HUD massimo quattro cuori, quindi si consiglia di non mettere un valore più alto di quattro. Tuttavia, basta aggiungere quanti cuori si vogliano nel container dei cuori dell’HUD);
•	HealthSignal: è un Signal Sender e manda il segnale per aggiornare la salute del personaggio, facendo collaborare i cuori dell’HUD e la salute effettiva del personaggio;
•	Monete: è un Signal Sender e manda il segnale per aggiornare il contatore delle monete, facendo collaborare il contatore dell’HUD con le monete effettive nell’inventario;
•	PlayerInventory: è di tipo Inventory e tiene traccia delle cose che troviamo all’interno dell’inventario del personaggio.


Script


Di seguito vengono elencati i vari script creati per realizzare il progetto.

Movimento


Questo script serve principalmente al movimento del nostro personaggio, tuttavia, contiene anche altri metodi che servono ad altro. All’interno troviamo:
•	Knock(): gestisce il caso in cui il nostro personaggio subisce danno: quando subiamo il danno, se la nostra salute sarà maggiore di zero, allora verrà eseguita la Coroutine “KnockCo()”, che permette di cambiare lo stato del nostro personaggio e di farcelo rimanere per un determinato periodo; se invece la salute sarà uguale o minore di zero, il nostro personaggio morirà, comparirà un’animazione e verrà richiamata la schermata di Game Over;
•	KnockCo(): viene richiamato dal metodo Knock() quando il nostro personaggio subisce danno, ma ancora rimane in vita;
•	DeathEffect(): è un metodo che istanzia l’animazione di morte del personaggio e viene richiamato dal metodo Knock();
•	MovimentoPG(): serve per muovere il personaggio nel gioco usando Rigidbody.MovePosition(). Il movimento del nostro personaggio varierà anche in base alla velocità che impostiamo;
•	UpdateAnimationAndMove(): collega il movimento del nostro personaggio alle giuste animazioni. Richiama MovimentoPG();
•	AttackCo(): imposta lo stato del nostro personaggio (in base a se stiamo attaccando);
•	Start(): inizializza le nostre variabili e imposta lo stato iniziale del personaggio;
•	Update(): aggiorna il movimento del personaggio. Inoltre, se stiamo attaccando, verrà eseguita la Coroutine AttackCo(); se invece ci stiamo muovendo verrà richiamato il metodo UpdateAnimationAndMove().


Nemici


Questo script contiene vari metodi utili a tutti i tipi di nemici che si potrebbero inserire nel gioco, ricevendoli tramite ereditarietà. Troviamo:
•	Awake(): inizializza la vita dei nemici in base alla difficoltà del gioco scelta;
•	TakeDamage(): gestisce la vita dei nemici, aggiornandola ad ogni hit ricevuto. Se il nemico viene sconfitto: viene incrementato il contatore dello score; viene richiamato il metodo DeathEffect() per far partire l’animazione di morte; se il nemico era il boss, viene richiamata la schermata di vittoria;
•	DeathEffect(): istanzia l’animazione di morte del nemico e viene richiamata dal metodo TakeDamage();
•	Knock() e KnockCo(): sono molto simili ai metodi omonimi che troviamo nello script “Movimento”, ma qui Knock() richiama TakeDamage() e quindi non gestisce direttamente né la vita del nemico, né il caso in cui il nemico muoia;


minion


Questo script estende ed eredita i metodi dello script Nemici. Troviamo:
•	ChangeState(): permette di cambiare lo stato del minion (il nemico in questione). Gli stati sono stati citati prima, ma si trovano in una enum all’interno dello script Nemici;
•	changeAnim(): serve per cambiare l’animazione del minion e impostare quella giusta in base la direzione che sta seguendo. Utilizza il metodo SetAnimFloat() per svolgere questo lavoro, dopo aver fatto gli opportuni controlli;
•	SetAnimFloat(): serve ad impostare i giusti vettori di direzione, in modo da utilizzare l’animazione adeguata. Viene richiamata dal metodo changeAnim();
•	CheckDistance(): implementa il comportamento del minion in presenza del suo target (il nostro personaggio) entro un determinato raggio d’azione. Richiama changeAnim() e ChangeState() per cambiare le animazioni e lo stato del minion;
•	FixedUpdate(): richiama CheckDistance() per controllare continuamente se il target è dentro il raggio d’azione;
•	Start(): inizializza le varie variabili dello script.


CambioStanza


Questo script viene utilizzato per le transizioni che avvengono quando si entra in una nuova stanza. Troviamo:
•	OnTriggerEnter2D(): serve a “portare” la telecamera nella stanza in cui si trova il nostro personaggio;
•	Start(): istanzia la telecamera.


CameraM


Viene utilizzato per permettere alla telecamera di seguire il nostro personaggio. Troviamo:
•	LateUpdate(): in base alla posizione del target regola la posizione della telecamera, frame per frame.


Knockback


Questo script viene utilizzato sia per il personaggio che per i nemici. Implementa il danno da hit, il tempo di stordimento e l’effettivo “rimbalzo all’indietro” quando si subisce una hit. Troviamo:
•	OnTriggerEnter2D(): implementa l’effettivo rimbalzo dovuto al ricevere di una hit, e cambia lo stato di chi subisce l’attacco (mettendolo nello stato “stagger”).


Score


Questo script viene utilizzato per mostrare lo score a schermo. Troviamo:
•	Start(): inizializza una variabile Text;
•	Update(): aggiorna la variabile Text con lo score corretto. Lo score viene aggiornato dallo script Nemici.


Tentativi


È una classe statica che implementa l’incremento e il reset del contatore dei tentativi utilizzando i “PlayerPrefs”. Durante una sessione di gioco, il contatore verrà incrementato ogni volta che verrà fatta una nuova partita. All’uscita del gioco verrà resettato a zero. Troviamo:
•	PlayCount(): metodo statico che ritorna il valore del contatore;
•	IncrementPlayCount(): incrementa e setta il contatore per poi salvare il tutto tramite i PlayerPrefs;
•	ResetPlayCount(): Setta il contatore a zero.


TentativiDisplay


Questo script viene utilizzato per mostrare i tentativi a schermo. Troviamo:
•	Start(): inizializza una variabile Text;
•	Update(): aggiorna la variabile Text.


PauseManager


Permette di visualizzare le varie schermate di “blocco gioco”: quando si decide di mettere in pausa, quando si vince e quando si perde. Troviamo:
•	Start(): inizializza le varie variabili;
•	Update(): controlla se venga premuto il tasto “escape” e che le altre schermate non siano attivate (vittoria e game over). Richiama ChangePause() in caso di pausa;
•	ChangePause(): se il gioco viene messo in pausa attiva la schermata di pausa e blocca il gioco; se invece già siamo in pausa, e viene ripremuto il tasto escape (oppure premiamo il bottone “Riprendi” in gioco), la schermata viene disattivata e il gioco riprende. Viene richiamato da Update();
•	QuitToMain(): permette di tornare al menu principale quando premiamo sul bottone in gioco “Torna al menu”;
•	GameOver(): richiama la Coroutine GameOverRoutine();
•	GameOverRoutine(): attiva la schermata di Game Over e blocca il gioco; Viene richiamata da GameOver();
•	BossDefeated(): Richiama la coroutine BossDefeatedRoutine();
•	BossDefeatedRoutine(): attiva la schermata di vittoria, e blocca il gioco. Viene richiamata da BossDefeated().


Data


Contiene una enum che elenca le difficoltà del gioco.


GestioneMenu


Questo script serve a impostare la difficoltà della partita, iniziarne una nuova e per uscire dal gioco (l’uscita dal gioco funziona anche nell’editor in modo da testarlo). Troviamo:
•	Awake(): inizializza una variabile;
•	SetFacile(): imposta la difficoltà a “Facile”;
•	SetNormale(): imposta la difficoltà a “Normale”;
•	SetDifficile(): imposta la difficoltà a “Difficile”;
•	NuovaPartita(): incrementa il numero di tentativi, richiamando un metodo dello script Tentativi, e cambia la scena, permettendo di giocare ad una nuova partita;
•	Uscita(): permette di uscire dal gioco.


GestoreAudio


Permette di impostare una musica di sottofondo. Troviamo:
•	Awake(): inizializza le variabili;
•	Start(): gestisce delle impostazioni riguardante la musica (metterla in loop, il volume, ecc...);
•	UpdateSound(): regola il volume della musica in base allo slider che troviamo nelle opzioni del menu principale.


Trigger


È un interfaccia che dichiara il metodo “OnTriggerEnter2D()”. Verrà implementata dagli oggetti raccoglibili, come i cuori e le monete.


CambioRisoluzione, GestioneComandi e Keybindings(Problema noto)


Li ho voluti tenere e citare per completezza in quanto non funzionano bene. CambioRisoluzione funzionava solo in parte: qualsiasi risoluzione si sceglieva ne veniva impostata una dal gioco in cui la grafica era veramente di bassa qualità, infatti ho preferito togliere la tendina delle risoluzioni dal menu principale. Per quanto riguarda i comandi, essi vengono cambiati solo graficamente nel menu, e il sistema di salvataggio (almeno a livello grafico) funziona, infatti, anche quando il gioco viene chiuso, nel menu dei comandi rimangono le nostre scelte. Ho comunque deciso di lasciare il menu dei comandi in modo da poter visionare i comandi del gioco.


Powerup


Ha solo una variabile di tipo SignalSender che servirà per inviare il segnale in caso di cambiamenti del target (design pattern Observer).


Heart


Estende Powerup e implementa Trigger. Questo script implementa il comportamento del cuore che troviamo in gioco. Troviamo:
•	OnTriggerEnter2D(): incrementa la salute del nostro personaggio quando essa non è al massimo (ogni cuore cura due hit). Invia il segnale dell’avvenuto cambiamento e distrugge l’oggetto raccolto.


HeartManager


Serve per modificare gli sprite dei cuori dell’HUD. Troviamo:
•	Start(): richiama InitHearts();
•	InitHearts(): setta il container dei cuori al massimo della loro capienza (con gli sprite del cuore pieno);
•	UpdateHearts(): imposta gli sprite corretti in base alla salute del nostro personaggio (si parte da un cuore pieno; dopo una hit, il cuore pieno diventerà un cuore a metà; un cuore a metà, dopo una hit, diventerà un cuore vuoto).


Coin


Estende Powerup e implementa Trigger. Questo script serve a incrementare il contatore delle monete quando se ne raccoglie una. Troviamo:
•	OnTriggerEnter2D(): quando raccogliamo una moneta, incrementa il contatore delle monete, manda il segnale per notificare il cambiamento e distrugge l’oggetto.


CoinTextManager


Serve ad aggiornare il counter delle monete dell’HUD. Troviamo:
•	UpdateCoinCount(): aggiorna il contatore grafico delle monete.
