// Dichiarazione delle variabili
char[] lettere = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
string parolaScelta;
bool trovata;
bool vittoria = false;
int indiceCasuale;
int tentE = 10, tentM = 7, tentD = 5;
string diff;
string parolaFinale;
int cont = 0;
int partite = 0;
int sconfittetotali = 0;
int vittorietotali = 0;

while (partite < 3)  // Esegui fino a 3 partite
{
    Console.WriteLine("╔═════════════════════════╗");
    Console.WriteLine("║        WELCOME          ║");
    Console.WriteLine("╚═════════════════════════╝");

    string percorsoFile = "parole.txt"; // Percorso del file con le parole

    // Legge tutte le parole dal file in un array
    string[] parole = File.ReadAllLines(percorsoFile);

    // Genera un numero casuale per scegliere una parola
    Random rnd = new Random();
    indiceCasuale = rnd.Next(0, parole.Length);

    // Parola selezionata
    parolaScelta = parole[indiceCasuale];

    // Chiedi la difficoltà solo una volta
    Console.WriteLine("♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");
    Console.WriteLine("♥ Difficoltà:     ♥");
    Console.WriteLine("♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥♥");

    Console.WriteLine("• Easy---->10 tentativi");
    Console.WriteLine("• Medium---->7 tentativi");
    Console.WriteLine("• Difficult---->5 tentativi");

    Console.WriteLine("");

    Console.WriteLine("Choose: ");
    diff = Console.ReadLine();
    char[] scelta = new char[parolaScelta.Length];

    // Inizializza la parola da indovinare con "_" per ogni lettera
    for (int i = 0; i < parolaScelta.Length; i++)
    {
        scelta[i] = '_';
    }

    // Visualizza la parola con gli spazi vuoti
    Console.WriteLine(scelta);

    // Resetta lo stato della vittoria e dei tentativi ad ogni inizio partita
    vittoria = false;

    // Gestione della difficoltà
    int tentativi = 0;
    if (diff == "Easy") tentativi = tentE;
    else if (diff == "Medium") tentativi = tentM;
    else if (diff == "Difficult") tentativi = tentD;

    while (tentativi > 0 && !vittoria)
    {
        Console.WriteLine("");
        Console.WriteLine("Tentativi rimanenti: " + tentativi);
        Console.WriteLine("");
        Console.WriteLine("parola o lettera");
        string risposta = Console.ReadLine();

        if (risposta == "parola")
        {
            Console.WriteLine("Dimmi la parola:");
            string ripostaFinale = Console.ReadLine();

            if (parolaScelta == ripostaFinale)
            {
                Console.WriteLine("══════════════");
                Console.WriteLine("OTTIMO LAVORO!");
                Console.WriteLine("══════════════");
                vittoria = true;
                break;
            }
            else
            {
                Console.WriteLine("═══════════════════════════════════");
                Console.WriteLine("OCCHIO L' IMPICCAGIONE SI AVVICINA!");
                Console.WriteLine("═══════════════════════════════════");
            }
        }
        if (risposta == "lettera")
        {
            trovata = false;
            Console.Write("Inserisci una lettera: ");
            char lettera = Console.ReadLine()[0];

            if (parolaScelta.Contains(lettera))
            {
                for (int i = 0; i < parolaScelta.Length; i++)
                {
                    if (parolaScelta[i] == lettera)
                        scelta[i] = lettera;
                }
            }
            else
            {
                tentativi--;
            }

            Console.WriteLine(scelta);

            // Controlla se tutte le lettere sono state trovate
            cont = 0;
            for (int i = 0; i < parolaScelta.Length; i++)
            {
                if (parolaScelta[i] == scelta[i])
                {
                    cont++;
                }
            }

            if (cont == scelta.Length)
            {
                vittoria = true;
            }
        }
    }

    // Risultato della partita (gestito dopo il ciclo while)
    if (vittoria)
    {
        vittorietotali++;
        Console.WriteLine("═════════");
        Console.WriteLine("HAI VINTO");
        Console.WriteLine("═════════");
    }
    else
    {
        // Incrementa sconfittetotali solo se il giocatore ha esaurito i tentativi e non ha vinto
        sconfittetotali++;
        Console.WriteLine("═════════");
        Console.WriteLine("HAI PERSO");
        Console.WriteLine("═════════");
    }

    // Incrementa il contatore delle partite solo se la partita è stata completata
    partite++;
}

// Mostra i risultati finali dopo 3 partite
Console.WriteLine("");
Console.WriteLine("RISULTATI FINALI");
Console.WriteLine("");
Console.WriteLine("Partite giocate: " + partite);
Console.WriteLine("Partite vinte: " + vittorietotali);
Console.WriteLine("Partite perse: " + sconfittetotali);
Console.WriteLine("");

if (vittorietotali > sconfittetotali)
{
    Console.WriteLine("OTTIMO SEI RIUSCITO A PERDERE POCHE VOLTE!");
}
else
{
    Console.WriteLine("AH PECCATO, VABBE LA PROSSIMA VOLTA TI RIFARAI");
}

