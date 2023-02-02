using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using System.Linq;

// https://drive.google.com/drive/folders/1xRqdEur1-v4Vcronc2xluD8oeouW3CqV
// https://docs.google.com/spreadsheets/d/1NvRtgHDORbWYLZfMRCDxnZJ6RUp-v8MAALUPw32ePJg/edit#gid=0
// https://products.aspose.app/cells/fr/conversion/excel-to-json
// https://docs.google.com/document/d/1JNzpcNSqdSMorMf9A-5lsGXNjfRFnQBLWaasmCMGZ_U/edit

[System.Serializable]
public class NPC : MonoBehaviour
{

    public Transform ChatBackGround;
    public Transform NPCCharacter;

    private DialogueSystem dialogueSystem;

    public string Name;
    public int Age;
    public string Sexe;
    public string Peuplade;
    public string Metier;
    public int Taille;
    public int Poids;

    public int Force;
    public int Agilite;
    public int Endurance;
    public int Intelligence;

    public int Charme;
    public string Alignement;
    public int Reputation;
    public string Personnalite_process;
    public int Morale;

    public int RelationAvecJoueur;

    public string Quete;
    public string Proximite;
    public string Rumeur;
    public string resultat;
    public int Qui;
    public string currentNPCName;

    public PlayerInventory playerInventory;
    public DialogueSystem script;

    public string GetSexe()
    {
        int Sexe = Random.Range(0, 1);
        if (Sexe == 0)
        {
            Name = "" + GetRandomPrenomMasculin() + " " + GetRandomNom();
            return "masculin";
        }
        else
        {
            Name = "" + GetRandomPrenomFeminin() + " " + GetRandomNom();
            return "feminin";
        }
    }

    public int GetAge()
    {
        int Age = Random.Range(14, 70);
        return Age;
    }

    public int GetTaille()
    {
        int Taille = Random.Range(130, 190);
        return Taille;
    }

    public int GetPoids()
    {
        int Poids = Random.Range(40, 120);
        return Poids;
    }

    public int GetCharme()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public string GetAlignement()
    {
        return alignement[Random.Range(0, alignement.Length)];
    }

    public int GetReputation()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public string GetPersonnalite_process()
    {
        return personnalite_process[Random.Range(0, personnalite_process.Length)];
    }

    public string GetPeuplade()
    {
        return peuplade[Random.Range(0, peuplade.Length)];
    }

    public string GetMetier()
    {
        return metier[Random.Range(0, metier.Length)];
    }

    public int GetForce()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public int GetAgilite()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public int GetEndurance()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public int GetIntelligence()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public int GetMorale()
    {
        int resultat = Random.Range(0, 100);
        return resultat;
    }

    public int GetRelationAvecJoueur()
    {
        int resultat = Random.Range(10, 70);
        return resultat;
    }

    private string[] peuplade = new string[] {
        "Homme du Nord", "Homme du Sud", "Homme de l'Est", "Homme de l'Ouest", "Homme du Grand Nord", "Homme du Grand Sud", "Homme du Grand Est", "Homme du Grand Ouest", "Asiatique", "Africain", "Latin", "demi-Elfe"
        , "Petite personne", "Nain", "Elfe", "demi-Orque", "demi-Ogre", "Caucasien", "Elfe noir", "Haut-elfe", "Elfe sylvain", "Nain des collines", "Nain des hautes montagnes", "Homme des montagnes", 
        "Homme des plaines", "Homme de l'Empire", "Homme du massif central", "Mi-elfe Mi-Nain", "Halfling", "Hauts Hommes", "Homme des îles"
     };

    private string[] metier = new string[] {
        "Marchand", "Aubergiste", "Servant", "Paysan", "Noble", "Bailleur", "Erudit", "Sans Emploi", "Vagabond", "Voyageur", "Aventurier", "Homme d'église", "Mercenaire", "Emissaire", "Forgeron", "Tisserand", "Bûcheron", "Charpentier",
        "Boulanger", "Bâtisseur"
     };


    private string[] alignement = new string[] {
        "Loyal Bon", "Loyal Neutre", "Loyal Mauvais", "Neutre Bon", "Neutre strict", "Neutre Mauvais", "Chaotique Bon", "Chaotique Neutre", "Chaotique Mauvais"
     };

    private string[] personnalite_process = new string[] {
        "Rêveur", "Rebelle", "Promoteur", "Empathique", "Travailleur", "Persévérant"
     };

    private string[] reveur = new string[] {

        "",	">:(",	"8|",	":@",	"'",	"*effleurer*",	"*regarder au loin*",	"*regard*",	"je vous en prie",	"prier",	"croire",	"*regarder en l'air*",	
        "*regarder dans les yeux*",	"*renifler*",	"espérer",	"solitude",	"sentiment",	"un jour",	"peut être",	"beau",	"Réfléchissez",	"parlons-en",	
        "je ne sais pas",	"que",	"lait",	"idéaliste",	"distrait",	"utopiste",	"philosophe",	"contemplatif",	"mélancolique",	"éveillé",	"lunaire",	"poète",	
        "rêveusement",	"solitaire",	"visionnaire",	"insouciant",	"pensif",	"poétique",	"songeur",	"soucieux",	"penseur",	"absorbé",	"abstrait",	"chimérique",	
        "contemplateur",	"enthousiaste",	"méditatif",	"Pierrot",	"préoccupé",	"sentimental",	"imaginatif",	"lucidité",	"romanesque",	"romantique",	
        "indécis",	"naïf",	"rêver",	"laisse",	"sombre",	"absent",	"ailé",	"assembleur de nuées",	"chavirer",	"dans les nuages",	"devin",	"éberlué",	
        "écervelé",	"étourdi",	"étourdir",	"évaporer",	"fainéant",	"idéalisateur",	"idéologue",	"illuminer",	"imprudent",	"inattentif",	"inconsidéré",	
        "ingénu",	"innocent",	"irréfléchi",	"langoureux",	"léger",	"occuper",	"pelleteux de nuages",	"prophète",	"recueilli",	"rêvasseur",	"songe - creux",	
        "spéculatif",	"rêve",	"imagine",	"pense"

   };

    private string[] rebelle = new string[] {
     
        ":'D",	":D",	":P",	"8x",	"!",	":)",	";)",	":~)",	"*accolade*",	"*pousser*",	"*toucher*",	"*provoquer*",	"*grimace*",	"*rire*",	
        "pas mal",	"ça roule",	"super",	"génial",	"fun",	"acceptable",	"fou",	"incroyable",	"tordu",	"c'est parti",	"cool",	"révolté",	"insoumis",	
        "réfractaire",	"indocile",	"indomptable",	"mutin",	"récalcitrant",	"factieux",	"séditieux",	"insurgé",	"traître",	"ingrats",	"princesse",	
        "mèche",	"tenace",	"désobéissant",	"entêté",	"guérillero",	"hostile",	"obstiné",	"opiniâtre",	"perturbateur",	"résistant",	"dissident",	
        "joue",	"subversif",	"Homs",	"rétif",	"révolutionnaire",	"piège",	"armée",	"embuscade",	"mercenaires",	"astuce",	"liberté",	"transfuge",	
        "troupes",	"armés",	"je suis libre",	"impropre",	"loyaliste",	"tu es libre",	"répression",	"libre",	"joug",	"résiste",	"amuse toi",	"agitateur",	
        "anticonformiste",	"blasphémateurs",	"chef",	"combattant de la liberté",	"comploteur",	"contestataire",	"contrariant",	"déchaîné",	"dérangeant",	"difficile",	
        "discordant",	"dissiper",	"égarer",	"émeutier",	"ennemi",	"espiègle",	"extrémiste",	"fermé",	"forte tête",	"frondeur",	"fusiller",	"hors-la-loi",	
        "imperméable",	"incontrôlé",	"indépendant",	"indisciplinable",	"indiscipliné",	"inédit",	"infranchissable",	"insensible",	"insubordonné",	"insurrectionnel",	
        "libre",	"maquisard",	"mécontent",	"conformiste",	"opposant",	"opposé",	"perturbant",	"protestataire",	"regimbeur",	"solide",	"soumettre",	
        "sourd",	"terroriste",	"têtu",	"trublion",	"tumultueux",	"tyran",	"vicieux",	"plaisante",	"contact"

  };

    private string[] promoteur = new string[] {
     
        ":U",	":*)",	"d",	"Q",	":",	">:)",	">:P",	"^^",	"*gifler*",	"*toucher les fesses*",	"enchanté",	"*montrer du doigt*",	"*mimer combat*",	"*immiter*",	
        "épices",	"or",	"luxe",	"argent",	"jeux",	"vivant",	"marchand",	"manipulateur",	"sensation",	"défi",	"energie",	"immobilier",	"projet",	"architecte",	
        "transcription",	"ardent",	"inventeur",	"opéron",	"ADN",	"constructeur",	"entrepreneur",	"gène",	"urbanisme",	"ARN",	"précurseur",	"investigateur",	
        "propriétaire",	"construction",	"immeuble",	"ingénieur",	"initiateur",	"concepteur",	"créateur",	"fondateur",	"investisseur",	"novateur",	"pionnier",	"sponsor",	
        "eugénisme",	"infatigable",	"auteur",	"bâtiment",	"bruxellisation",	"premier",	"promoteur immobilier",	"réforme",	"activeur",	"agent",	"agent promoteur",	
        "âme",	"animateur",	"artisan",	"bailleur",	"bâtisseur",	"cause",	"centre",	"consensus",	"développeur",	"diffuseur",	"dirigeant",	"édificateur",	
        "éducateur",	"excitateur",	"fabricant",	"fauteur",	"forgeur",	"imprésario",	"innovateur",	"inspirateur",	"instaurateur",	"instigateur",	"introducteur",	
        "jeteur",	"lanceur",	"lotisseur",	"maçon",	"mécène",	"meneur",	"moteur",	"organisateur",	"ouvrier",	"parrain",	"père",	"point de départ",	"positif",	
        "programmeur",	"promotrice de régime",	"propagateur",	"protagoniste",	"proto - oncogène",	"réalisateur",	"répondant",	"répondant d'un régime",	"responsable",	
        "révélateur",	"séquence",	"site promoteur",	"vulgarisateur",	"intuition",	"chère",	"pièce",	"charmant",	"charmeur"

    };

    private string[] empathique = new string[] {
    ":$",   ":'(",	"?",	":)",	"<3",	":(",	"*main*",	"*saluer*",	"*s'inquiéter*",    "*masser*", "merci",    "*calin*",  
        "*main sur l'épaule*",	"*pleurer*",	"beaucoup",	"bienvenue",	"bonne nuit",	"bonjour",	"bonsoir",	"aimable",	"heureux",	
        "réconfort",	"chaleur",	"besoin",	"sentir",	"sympathie",	"compassion",	"empathique",	"sentiment",	"altruisme",	
        "capacité",	"émotion",	"affectif",	"bienveillance",	"ressentir",	"contagion",	"souffrance",	"contagion émotionnelle",	
        "éprouver",	"individu",	"altruiste",	"détresse",	"émotionnel",	"perception",	"attitude",	"sollicitude",	"ressenti",	"altérité",	
        "humain",	"percevoir",	"affect",	"bien-être",	"concrète",	"comprendre",	"décentration",	"déclencher",	"comprend",	"différencier",	
        "gentillesse",	"identification",	"indépendamment",	"interindividuelle",	"interlocuteur",	"intropathie",	"mental",	"miroir",	
        "partager",	"réplicant",	"survie",	"mental",	"miroir",	"partager",	"réplicant",	"survie",	"je comprend",	"tu as raison",	
        "raconte moi",	"dis moi",	"ça va",	"ça ne va pas",	"attendrissement",	"commisération",	"empathie",	"humanité",	"pitié",	
        "sensibilité",	"sympathie",	"désolé",	"escuse moi",	"pardon",	"ça va ?",	"tout va bien ?",	"chaleureux",	"nourricier",	
        "psychologue",	"parler",	"amour",	"je t'aime",    "je t'apprécie",	"je t'ecoute",  "aime", "apprécie"
    };

    private string[] travailleur = new string[] {
        "ok",   "%|",   ":=|",  ".",    "(",    ")",    "8|",   "*air sérieux*",    "*interrogatif*",   "demain",   "hier", "*racler sa gorge*",    
        "*regarder autour de soi*", "*mesurer quelque chose*",  "aujourd'hui",	"quoi",	"qui",	"comment",	"où",	"compétent",	"à propos",	"concentration",	
        "contrôle",	"voilà",	"factuel",	"travaille",	"ouvrier",	"salarié",	"salaire",	"travail",	"capital",	"syndicat",	"prolétariat",	"capitaliste",	"emploi",	
        "employeur",	"productivité",	"travailleuse",	"acharné",	"chômage",	"chômeur",	"prolétaire",	"clandestin",	"patron",	"communiste",	"honnête",	"grève",	
        "infatigable",	"Marx",	"socialisme",	"ouvrière",	"rémunération",	"socialiste",	"syndicalisme",	"autogestion",	"collectivisme",	"employés",	"handicapé",	
        "main-d'œuvre",   "patronat", "social",   "productif",    "qualifié", "immigré",  "assurance",    "journalier",   "prolo",    "anarchisme",   "capitalisme",  "consciencieux",    
        "consommateur", "embauche", "fonctionnaire",    "intérimaire",  "minimum",  "saisonnier",   "travailler",   "zélé", "bosseur",  "communisme",   "confédération",    
        "courageux",    "émancipation", "frontalier",   "licenciement", "militant", "allocation",   "association",  "Bakounine",    "chantier", "labeur",   "producteur",   
        "exploitation", "fainéants",    "indépendant",  "moyens de production", "Proudhon", "révolutionnaire",  "stakhanovisme",    "syndicaliste", "agricole", "amiante",  
        "condition",    "étudiant", "libertaire",   "marxisme", "plus - value", "secteur",  "union",    "actif",    "besoin",   "congé",    "diligent", "employer", "étranger", 
        "manouvrier",   "manuel",   "allons y"
     };

    private string[] perseverant = new string[] {
        ":O",   ":()",  ":'O",	":/ ",	".",	" * saluer * ",	" * s'incliner*",	"*caresser*",	"oui",	"non",	"bien sur",	"*regarder le sol*",	"*prendre sa tête*",	
        "*main sur la bouche*",	"évidemment",	"j'aimerais ",	"je pense",	"et toi ?",	"pourquoi",	"confiance",	"croisade",	"conviction",	"surtout",	"avant tout",	
        "premierement",	"perseverant",	"patient",	"opiniâtre",	"tenace",	"courageux",	"fidèle",	"obstiné",	"courage",	"continu",	"durable",	"énergique",	
        "ferme",	"infatigable",	"constant",	"déterminé",	"endurant",	"éprouvé",	"têtu",	"élever",	"résolu",	"accentuer",	"acharné",	"appuyer",	"assidu",	
        "attaché",	"buté",	"client",	"conséquent",	"continuel",	"coriace",	"dur",	"entêter",	"fixe",	"incessant",	"inflexible",	"ininterrompu",	"malade",	
        "noble",	"permanent",	"persistant",	"résigner",	"résistant",	"seconder",	"soutenir",	"stoïque",	"suivi",	"volontaire",	"zélé",	"pièce",	"charmant",	
        "charmeur"
    };



    private string[] prenoms_masculins = new string[] { 
        "Olivier", "Jean", "David", "Arthur", "Bertrand", "Gotran", "Amaury", "Anthiaume", "Barthélémi", "Audibert", "Benoît", "Bohémond", "Edmond",
        "Enguerrand", "Ernaut", "Eudes", "Galaad", "Coulomb", "Garin", "Gauthier", "Gauvain", "Gibouin", "Gilemer", "Godefroy", "Gonzagues", "Grégoire",
        "Anselme", "Aymeric", "Guilhem", "Hardouin", "Hubert", "Herchambaut", "Raymond", "Robert", "Roland", "Savari", "Tancrède", "Thibaut", "Tristan",
        "Yvain", "Faust", "Faron", "Fulbert", "Garibald", "Gebehard", "Edwin", "Dietrich", "Dagulf", "Gotran", "Cunibert", "Crispin", "Cotron",
        "Urbain", "Conghall", "Clothaire", "Clodion", "Bertrand", "Liobbe", "Blaise", "Arichis", "Arimbert", "Closinde", "Athaloc", "Ealdight", "Beppolène",
        "Gripon", "Gozlin", "Gerbert", "Gandelin", "Génialis", "Gebehard", "Frédégaire", "Théodrade", "Thècle", "Alix", "Adovaire", "Aistulf", "Amolon",
        "Abel", "Acharie", "Adalard", "Adalbéron", "Adalmar", "Adaloald", "Adeichis", "Adon", "Adovaire", "Aega", "Aegila", "Aeginan", "Aethaire", "Aethelstan", 
        "Agilbert", "Agile", "Agilulf", "Agobard", "Aignan", "Aimoin", "Ainmar", "Aistulf", "Alard", "Alaric", "Alboin", "Alcuin", "Aldric", "Aléthée", "Amalaire", 
        "Amalgaire", "Armand", "Amé", "Amolon", "Anastase", "Andarchie", "Andegaire", "Animode", "Ansegis", "Anségisèle", "Ansoald", "Anthémiole", "Apahida", 
        "Apollinaire", "Apruncule", "Aptachaire", "Arambert", "Arbogast", "Arcadie", "Ardobert", "Arédie", "Arichis", "Arimbert", "Arioald", "Aripert", "Armentaire",
        "Arnoul", "Aspar", "Astier", "Astreuil", "Athalaric", "Athaloc", "Athanagilde", "Athaulf", "Aunon", "Aunulf", "Aurélien", "Ausone", "Auspice", "Austade",
        "Austremoine", "Austrin", "Autbert", "Authaire", "Autharic", "Autharis", "Avit", "Badegésile", "Baderic", "Baldaric", "Balduin", "Baudoin", "Baronte", 
        "Basile", "Basilisc", "Basin", "Bauto", "Bède", "Bélisaire", "Beowulf", "Beppolène", "Berchaire", "Berchier", "Bérenger", "Beroul", "Berthachar", "Berthaire", 
        "Bertin", "Bertoald", "Beuves", "Bibracte", "Bladaste", "Blaise", "Bobolène", "Bodégisile", "Bodo", "Bond", "Boniface", "Bonite", "Boson", "Bouchard",
        "Brodulf", "Brunon", "Buccelin", "Caedmon", "Cagnéric", "Cagnoald", "Carausie", "Caribert", "Carloman", "Cassiodore", "Castin", "Caton", "Celse", "Césaire", 
        "Chadoinde", "Chairerd", "Chanao", "Chappa", "Chararic", "Chariulf", "Charivald", "Childebert", "Childéric", "Chilpéric", "Chlochilaic", "Chramne", "Chramnelène", "Chremnolène", "Chroce", "Chrodegang", "Chrodin", "Chrodoald", "Chuldéric", "Chundon", "Ciucilon", "Cleph", "Clodéric", "Clodion", "Clodoald", "Clodomir", "Clothaire", "Clovis", "Colomban", "Conan", "Conghall", "Conobre", "Constance", "Constantin", "Corbe", "Cotron", "Crispin", "Cunibert", "Cunipert", "Cyprien", "Cyrola", "Dacco", "Dadon", "Dagaric", "Dagobert", "Dagulf", "Delphin", "Dentelin", "Desidére", "Desle", "Dietrich", "Dioclétien", "Domigisèle", "Domitien", "Donat", "Dracolène", "Droctigisile", "Droctulf", "Drogon", "Druse", "Ebbon", "Eberegisèle", "Ebles", "Ebrachaire", "Ebroïn", "Ecdice", "Edbald", "Edobec", "Edwin", "Effroy", "Eginhard", "Eifel", "Eleuthère", "Eloi", "Emery", "Ennodie", "Eptadie", "Eraric", "Erchinoald", "Erispoé", "Ermenfroi", "Ethelbert", "Eudes", "Eufraise", "Eumie", "Euphronie", "Euric", "Elric", "Eric", "Eusèbe", "Euspice", "Eustaise", "Eustoche", "Eutharic", "Evrard", "Faron", "Faust", "Ferréol", "Flachoald", "Flodoard", "Flore", "Fortunat", "Foulque", "Frédégaire", "Fridugis", "Fromond", "Frontin", "Fulbert", "Fulrad", "Gaidéris", "Gaifier", "Galien", "Gall", "Gandelin", "Ganelon", "Garibald", "Gaugeric", "Gautier", "Gebehard", "Gélimer", "Génialis", "Gennobaude", "Genserix", "Gerbert", "Germain", "Gervold", "Gésalic", "Geté", "Gewilib", "Gislemar", "Goar", "Godefroy", "Godégisile", "Godin", "Godomer", "Godopert", "Gondahar", "Gondebaud", "Gondioch", "Gondovald", "Gonthier", "Gordien", "Gotmar", "Gozlin", "Gratien", "Grifon", "Grimaud", "Grimo", "Grimoald", "Grindion", "Gripon", "Guérin", "Gui", "Guibert", "Guimar", "Guinemenz", "Gundichar", "Gundohine", "Gundulf", "Gunther", "Gygès", "Hadrien", "Haganon", "Hagnéric", "Harding", "Harold", "Hatton", "Heiric", "Helgaud", "Hélisachar", "Hèlouin", "Hermanfrid", "Herménégild", "Hermeuric", "Hésiode", "Hilaire", "Hidebrand", "Hilduin", "Hincmar", "Honorat", "Hrolf", "Hucbald", "Hugobert", "Hunaud", "Hunoald", "lbba", "Ildibad", "Ingomer", "Injurieux", "Innocent", "Isidore", "Judicael", "Just", "Justinien", "Konrad", "Lambert", "Lantfrid", "Léger", "Leif", "Lépide", "Leudégisèle", "Leudovald", "Leuthaire", "Liutprand", "Liuva", "Liuvigild", "Lothaire", "Loup", "Lucain", "Lulle", "Lupicin", "Macaire", "Maclou", "Magneric", "Magnovald", "Maixent", "Mallulphe", "Mamert", "Manassès", "Marbode", "Marcomir", "Marileif", "Marlot", "Martial", "Materne", "Mauregato", "Maximin", "Médard", "Mérobald", "Merowig", "Mesmin", "Milon", "Mummole", "Mummolène", "Mundéric", "Narsès", "Nectaire", "Nicaise", "Nigel", "Nizier", "Nominoé", "Nordebert", "Notker", "Occila", "Odelric", "Odilbert", "Odilon", "Odoacre", "Odon", "Offa", "Ollon", "Omer", "Oppila", "Orderic", "Oreste", "Othon", "Pacome", "Papoul", "Paschase", "Paterne", "Paulin", "Pégase", "Pelage", "Péone", "Pépin", "Perctarit", "Phébade", "Philibert", "Piat", "Plato", "Pline", "Polycarpe", "Potentien", "Prétextat", "Primat", "Procope", "Protadie", "Quintiane", "Quiriace", "Raban", "Radagaise", "Radbod", "Radelchis", "Radelgaire", "Radon", "Radulf", "Ragnacaire", "Rainfroi", "Rainon", "Rannoux", "Ratchis", "Rauching", "Reccared", "Receswinthe", "Remacle", "Renard", "Renaud", "Renier", "Reoval", "Richer", "Richomer", "Riothime", "Roccolène", "Rognvald", "Rollon", "Romaric", "Romulf", "Rorgon", "Roricon", "Rufin", "Rustique", "Sabaude", "Sadrégisile", "Sagittaire", "Salomon", "Salvien", "Samo", "Saturnin", "Savary", "Savinien", "Segéric", "Segondin", "Seguin", "Sérotin", "Servais", "Sévère", "Sèverin", "Sicaire", "Sicard", "Sicon", "Sidoine", "Sidon", "Sigebert", "Sigebrand", "Sigéric", "Siggon", "Sigismer", "Sigismond", "Sigulf", "Sindold", "Sisenand", "Sixte", "Solenne", "Stilicon", "Strabon", "Suger", "Sulpice", "Sunniulf", "Sunno", "Svinthila", "Syagre", "Sylvain", "Sylvestre", "Symmaque", "Symphorien", "Tefas", "Téotolon", "Teudon", "Théodahat", "Théodebald", "Théodebert", "Théodemer", "Théodémis", "Théodoric", "Théodulf", "Thibert", "Thorismond", "Thrasamund", "Totila", "Trudulf", "Ulfila", "Urbain", "Uron", "Ursin", "Vaast", "Vacandard", "Vafrés", "Valérien", "Venance", "Victorin", "Victrice", "Vidaste", "Virgile", "Vitigès", "Walbert", "Walderic", "Walla", "Wallia", "Wanba", "Wandalmar", "Wandrille", "Waratton", "Warin", "Warnachair", "Wat", "Welf", "Weroc", "Werpin", "Widukind", "Willibald", "Willibrod", "Winemer", "Winfrid", "Winnoc", "Wintrion", "Wisibald", "Witeric", "Wulfoad", "Zacharie", "Zwentibold"

    };

    private string[] prenoms_feminins = new string[] {
        "Adélaide", "Adruhic", "Aedilberge", "AelfIède", "AéIis", "Agleberthe", "Agnès", "Alboflède", "Alchima", "Aliénor", "Alix", 
        "Altildis", "Amalaberge", "Amalasonthe", "Anseflèse", "Ansegisèle", "Arégonde", "Armentarie", "Arnegonde", "Arsinoé", 
        "Ascyla", "Aubierge", "Audéarde", "Audofléde", "Audovére", "Auréa", "Ausgarde", "Auxtreberthe", "Austrigilde", "Basilie", "Basine", "Bathilde", "Baudenivie", "Béatrice", "Begga", "Bérengère", "Berthe", "Berthefride", "Berthilde", "Bertrade", "Bertrude", "Bilichilde", "Blanche", "Bobila", "Brigithe", "Brunehaut", "Brugondofare", "Burngithe", "Césarie", "Chrodièlde", "Chunsine", "CIodosinde", "Closinde", "Clotilde", "Clotsinde", "Colombe", "Constance", "Cornélia", "Croma", "Crona", "Cunégonde", "Cuthburge", "Déotéria", "Dhuoda", "Disciola", "Ealdight", "Eanswithe", "Earcongothe", "Elvira", "Emma", "Emnechilde", "Enide", "Ermengarde", "Ermentrude", "Eudoxie", "Eufrasie", "Eulalie", "Eusebia", "Fabiola", "Faileuba", "Fara", "Fausta", "Frédégonde", "Galswinthe", "Gerberge", "Gertrude", "Girbalda", "Gisèle", "Gislaine", "Gisledrudis", "Gislildis", "Godelive", "Godiva", "Goisvinthe", "Guenièvre", "Hadewich", "Hedwige", "Héloise", "Hermensente", "Herminafride", "Herrade", "Hersende", "Hidburge", "Hilda", "Hildegarde", "Hiltrude", "Hrotswitha", "lngegarde", "Ingetrude", "Ingonde", "Irénée", "Judith", "Juliane", "Justina", "Jutta", "Lantechilde", "Lanthilde", "Lantilde", "Leticia", "Leuba", "Liliola", "Liobbe", "Lucia", "Magnatrude", "Mahaut", "Maloucha", "Mantie", "Marcatrude", "Marcovèfe", "Mathilde", "Maugalie", "Mechtilde", "Mélanie", "Mélisande", "Mélusine", "Méroflède", "Mildred", "Milésine", "Morgane", "Muriel", "Nantechilde", "Nanthilde", "Nantilde", "Olga", "Orengarde", "Osburge", "Papianille", "Pappolène", "Paula", "Pélagie", "Pétronille", "Philippa", "Piacidie", "Placidine", "Plectrude", "Radegonde", "Ragnetrude", "Regelindis", "Rita", "Rogneda", "Rothilde", "Salaberge", "Septimine", "Sibylle", "Sichilde", "Sophicie", "Suanahilde", "Syre", "Tecla", "Telchilde", "Téodechilde", "Tetradie", "Tetta", "Thècle", "Théodechilde", "Théodelinde", "Théodrade", "Théophane", "Urraca", "Vénérande", "Vera", "Viviane", "Vulfégonde", "Vultetrade", "Wanda", "Wisigarde"
    };

    private string[] noms = new string[] { 
        "de Clairefontaine ", "de Courtelande ", "le Taciturne ", "Dent-de-Loup", "de Montbard", "de Neuville",
        "d'Aiglemont", "de Bénévent  ", "Pelletier", "Courtois", "Roux", "Le Blond",
        "de Fiercastel", "de Blancmoustier ", "Cabrera", "Métivier", "Chauvin", "Delfosse",
        "de Valvert  ", "de Sassenage ", "Messonnier", "Pelletier", "Sarrazin", "Caretenier",
        "d'Engoulevent  ", "de Mancini ", "Rabier", "Fromentin", "Lenain", "Descamps",
        "de Beaulieu ", "Marchand", "Boulanger", "Larsonneur", "Legros", "Cauchie",
        "Marinier", "Serdun", "Mongolmy", "Destru", "Leacha", "Deschamps", "Martin", 
        "Bernard", "Thomas", "Petit", "Robert", "Richard", "Durand", "Dubois", "Moreau", "Laurent", "Simon", 
        "Michel", "Lefebvre", "Leroy", "Roux", "David", "Bertrand", "Morel", "Fournier", "Girard", "Bonnet", 
        "Dupont", "Lambert", "Fontaine", "Rousseau", "Vincent", "Muller", "Lefevre", "Faure", "Andre", "Mercier",
        "Blanc", "Guerin", "Boyer", "Garnier", "Chevalier", "Francois", "Legrand", "Gauthier", "Garcia", "Perrin", 
        "Robin", "Clement", "Morin", "Nicolas", "Henry", "Roussel", "Mathieu", "Gautier", "Masson", "Marchand", "Duval", 
        "Denis", "Dumont", "Marie", "Lemaire", "Noel", "Meyer", "Dufour", "Meunier", "Brun", "Blanchard", "Giraud", "Joly", 
        "Riviere", "Lucas", "Brunet", "Gaillard", "Barbier", "Arnaud", "Martinez", "Gerard", "Roche", "Renard", "Schmitt", 
        "Roy", "Leroux", "Colin", "Vidal", "Caron", "Picard", "Roger", "Fabre", "Aubert", "Lemoine", "Renaud", "Dumas", "Lacroix", 
        "Olivier", "Philippe", "Bourgeois", "Pierre", "Benoit", "Rey", "Leclerc", "Payet", "Rolland", "Leclercq", "Guillaume", "Lecomte"
    };

    //1 : rumeur
    //2 : monstre
    //3 : tresor
    //4 : spiritualite
    //5 : recherche
    //6 : ressource
    //7 : politique
    //8 : guilde
    //9 : escarmouche

    //intro
    private string[] intro = new string[] {
        "J'ai entendu dire que ", "Il parait que ", "J'ai ouïe dire ", "Ecoutez moi, ", "A ce propos, ", "J'ai une idée pour vous, ",
        "", "Prenez note, ", "Attendez, ", "Alors justement, ", "Ah oui, ", "ça me fait penser, ",
        "J'ai une mission pour vous, ", "J'ai quelque chose pour vous, ", "Oui tout à fait, ", "Tendez l'oreille, ", "", "",
        "", "", "", "", "", "", "j'ai entendu dire quelque chose d'étrange, ", "j'ai ouïe dire quelque chose de dingue, ", "il parait... attendez vous n'êtes pas prêt...", 
        "Vous savez ce qui se dit ?", "Approchez j'ai un secret pour vous !", " Vous ne connaissez pas la nouvelle ?", 
        "Vous allez halluciner de ce que je vais vous dire !", "Préparez vous au pire", "Ecoutez moi bien", "J'ai entendu des rumeurs...", 
        "Il court des bruits..", "Tout le monde en parle !", "C'est la nouvelle du moment !", "Vous n'allez pas me croire", "C'était sur toutes les bouches."
    };

    //qui
    private string[] qui = new string[] {
        "un troll", "des gobelins", "un vampire", "des loups", "un ours", "des orques", "un géant", "un dragon", "une vouivre", "le chef des bandits", 
        "un bandit", "un truand", "un mendiant", "un assassin", "un spectre", "un esprit", "un homme malveillant", "un sorcier", "une sorcière", 
        "un démon", "des rats", "des araignées", "des monstres affreux", "des choses ignobles", "une étrange présence", "le voisin", "une femme du village", 
        "le prêtre", "le chef du village", "le chasseur", "le curée", "ma voisine", "mon voisin", "ma mère", "mon fils", "la mère du chef du village", 
        "le père du petit grigory", "le boucher", "le fils du boulanger", "le boulanger", "la boulangère", "le tavernier", "un soldat de la garde", "un pêcheur", 
        "une prostitué", "une fille de petite vertu", "un chat", "un chien", "un lapin", "un druide", "un moine", "l'herboriste", "un espion", 
        "le diacre", "un médecin", "un astrologue", "le bailli", "l'homme le plus riche du village", "tresorier", "le marquis", "le seigneur", 
        "le baron", "le vicomte", "le vicaire", "le doyen", "le comte", "l'eveque", "l'abbe", "l'intendant", "le roi", "le prince", "le fils de l'empereur", 
        "l'élu de la prophétie", "un elfe", "un nain", "un humain", "une fée", "une demi-homme", "un demi-elfe", "un aventurier", "un voyageur", 
        "un type pas net", "un drôle de voyageur", "un lutin", "un homme arbre", "un centaure", "un minotaure", "un cheval", "un étrange marchand", "un musicien"
    };

    //quand
    private string[] quand = new string[] {
        "l'autre soir", "il ya quelques temps", "hier soir ", "ce matin", "tout à l'heure", "il y a quelques semaines",
        "il y a 10 minutes donc très vite, dépêchez vous...", "il y a 30 minutes", "il y a 1h", "il y a 2h", "il y a 5h", "ce soir", "à minuit", "demain", 
        "après demain", "il y a une semaine", "il y a un mois", "il y a deux mois", "il y a quatre mois", "il y a six mois", "l'année dernière", "il y a 5 ans"
    };

    //quoi
    private string[] quoi = new string[] {
        "a prié le diable", "a perdu toute sa richesse", "est devenu riche", "a été tué", "a été violé", "a été assassiné", "est amoureux", 
        "est devenu fou", "a pété les plombs", "a tué toute sa famille", "a massacré tout une ville", "a perdu son dentier", "a été excommunié", 
        "s'est promené nu", "a mangé une pomme empoisonnée", "a danser sous la lune", "dort pied nu", "a été banni", "a gagné le grand prix", 
        " a découvert un dragon", "a inventé la poudre", "a découvert le feu", "a changé tout un village en pierre", "a mis feu à la grange", 
        "a fait tomber tous les criminelles de la région", "garde une pierre très précieuse", "a invoqué un démon !", "a annoncé la fin du monde", 
        "a vu un nain sans barbe !", "a révolutionné la science", "a perdu ses clefs", "a vendu sa maison", "est à la rue", 
        "est devenu sans domicile fixe", "était bourré", "a vomi dans l'église", "a déféquer dans la mairie", "sent mauvais", 
        "pu le fromage pourri", "a trouvé un trésor", "a déterré un manuscrit qui date de 50 ans", "court tous les soirs", 
        "ne mange jamais de légumes !", "ne mange jamais de viande", "se nourrit exclusivement de poisson"
    };

    //quoi_quete
    private string[] quoi_quete = new string[] {
        "a voulu me tuer",
        "m'a cambriolé",
        "m'a insulté",
        "m'a arnaqué",
        "me doit de l'argent"
    };

    //comment
    private string[] comment = new string[] {
        "tout doucement", "d'un coup", "sans crier gare", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
    };

    //ou
    private string[] ou = new string[] {
        "dans la forêt", "dans les égoûts", "dans le champs", "caché dans la ville", "dehors", "je ne sais ou !", "à l'est", "à l'ouest", 
        "au sud", "au nord", "quelque part", "dans un trou", "dans une grotte", "dans une ruine", "dans un cimetierre", "dans les montagnes"
    };

    //pourquoi
    private string[] pourquoi = new string[] {
        "cela terrorise les villageois", "nous avons eu des victimes", "c'est gênant", "c'est effrayant", 
        "mon frère est mort à cause de cette menace", "ma soeur est morte...", "j'ai perdu ma mère à cause de ce genre de montre", 
        "j'ai perdu mon père à cause de ce genre de montre", "j'ai perdu ma tante hier et je soupçonne ça", 
        "j'ai perdu mon oncle et je pense que c'est lié", "j'ai perdu ma famille, c'est terrible... ce fils de p... escusez moi je suis sous le choc vous comprenez...", 
        "j'ai peur", "tout le monde a peur", "nous avons peur", "la menace grandit", "la menace s'est infiltré partout !", "ils sont partout !", 
        "je suis terrifié", "ça devient problèmatique", "tout est devenu si sombre ces derniers jours à cause de cette menance", 
        "j'ai l'impression que je vais mourrir", "j'ai vu mon destin funeste approcher à grands pas...", 
        "ça presence me fatigue !", "j'en ai marre", "c'est ce qu'il faut faire !", "le chef l'a décidé", "les paysans en ont marre !", 
        "j'ai cru le voir dans mes toilettes ce matin", " je l'ai trouvé dans mon bain !", "il a assombri le ciel !", 
        "la magicienne du village m'a prédit que cette menace me tuera demain", "ma vie est en danger", "je me suis fait volé tout ce que j'avais", 
        "mes affaires disparaissent !", "j'ai perdu un projet précieux et ce n'est pas anodin !", "Je soupçonne ces montres de me voler mes économies", 
        "je soupçonne ce genre de malotru de piquer mes réserves...", "j'en peux plus !", "je ne veux plus les voir !", 
        "je veux en finir avec eux", "j'ai envie aha !"
    };

    //pourquoi_quete
    private string[] pourquoi_quete = new string[] {
        ", aidez moi s'il vous plait, je vous promet une récompense !"

    };

    //proxi positif
    private string[] proximiPositif = new string[] {
        "Messire ?", "Tout va bien ?", "Comment allez vous ?", "N'hésitez pas si vous avez besoin de quelque chose", "Faites attention à vous", "Attention !", "Ecoutez...", "Soyez attentif !",
        "pardon ?", "Vous avez dit quelque chose ?", "Partagez moi vos pensées", "Quelque chose vous tracasse", "Je vous attends", "Dites moi quelque chose", "Vous avez dit quelque chose ?", "hum hum",
        "Mes hommages messire", "Vous souhaitez quelque chose ?", "un instant...", "à tiens que voulez vous ?", "je vous demande pardon ?", "Vous revoilà ?", "Qu'est-ce que vous souhaitez ?",
        "Vous avez essayé de me parler ?", "Oui ?", "Plait-il ?", "Vous avez un message à me faire passer ?", "Qu'est-ce qui vous amène de si bon matin ?", "Vous avez quelque chose à me dire vous !",
        "Je vous en prie discutons !", "Venez me parler un peu", "N'hésitez pas si vous avez besoin de parler", "Je sens que quelque chose vous tracasse", "Essayez de me parler, vous allez voir je ne mord pas",
        "Allez je vous en prie parlez moi !", "Venez à moi", "Crachez le morceau !", "Il vous faut quelque chose", "Je crois que vous avez envie de me parler je me trompe ?", "Qu'est-que vous faites ?",
        "A tiens vous vous promnez comme moi ?", "Vous avez oublié quelque chose ?", "Que cherchez vous ?", "Vous êtes bien pressé !", "Il fait beau aujourd'hui non ?", "Vous aimez vous promener dans la nature ?",
        "c'est agréable de se promener aujourd'hui", "Je trouve qu'il fait beau, pas vous ?", "On se sent bien ici non ?", "J'ai préparer un bon repas ce soir", "Vous n'avez pas vu passé un chien par hasard?",
        "C'est fou comme le temps passe si vite !", "je n'en peux plus je suis extenué !", "ça se rafraichit le temps vous ne trouvez pas ?", "C'est incroyable, je l'avais posé ici tout à l'heure",
        "Qu'est-ce que c'est ennuyeux par ici", "Je ne sais pas quoi faire de mon temps libre", "C'est dingue comme le temps change sans arrêt ces jours-ci"
    };

    //proxi negatif
    private string[] proximiNegatif = new string[] {
        "Eloignez vous de moi", "Imbécile !", "Regardez ou vous posez les pieds, merci !", "Qu'est-ce que vous me voulez ?", "Allez vous en !", "Hein ?", 
        "Dégagez moi le passage", "Encore vous ?", "ça suffit de vous maintenant", "Je ne peux plus vous voir", "Qu'est-ce qui fait encore là celui là !", "C'est qui ce type ?", 
        "Qu'est-ce qui nous veut celui là ?", "Touriste...", "J'ai pas le temps de discuter", "foutez moi le paix!", "j'en ai déjà marre de vous", "c'est pas croyable comme on s'ennuie !",
        "Foutez moi le camp!", "J'aimerais être tranquille c'est possible ?", "Laissez moi, j'ai besoin de réfléchir...", "Je ne peux pas penser avec vous dans les parages",
        "Du balais !", "Oust !", "C'est pas vrai ça ! Je n'ai pas besoin d'un crétin dans les parages...", "Attention...", "Vous devriez vous méfier...", "Sortez de mon champs de vision",
        "Hors de ma vue !", "Circulez!", "Fichez moi la paix pour de bon !", "Voilà un mauvais présage..", "Vous en faites une de ces têtes...", "Ne m'approchez pas", "Pas un pas de plus !",
        "Je n'ai pas besoin de subir votre stupidité", "Loin, partez loin", "Qu'est- qu-il y a ?", "Il veut quoi lui ?", "Sortez de ma propriété !", "J'ai besoin d'air", "c'est quoi ça encore ?",
        "Vous croyez que j'ai que ça à faire de vous écouter", "C'est pas possible, encore vous ?", "Dégage le pitre", "Bouffon...", "Vous ne devriez pas trainer par ici", "Je ne vous aime pas",
        "Allez voir ailleurs si j'y suis !", "Vous me prenez pour un imbécile ?", "Qu'est-ce que j'ai dit ?", "Non, pas aujourd'hui", "Du balais bon sang !", "Nom de dieu !", "Il ne fait pas bon de trainer ici",
        "rentrez chez vous", "rentrez chez votre mère", "Vous n'avez pas mieux à faire que d'ennuyeux les honnêtes gens ?", "Je n'ai vraiment pas besoin de ça aujour'dhui...", "Sortez d'ici",
        "N'essayez même pas", "N'hésitez pas à déguerpir", "Attention je peux me facher", "Y'en a marre...", "Quoi ???", "Oh tu m'écoutes ?", "Passe ton chemin !", "Batard..", "Sale voleur !",
        "Je suis sur que vous êtes un vagabond !", "Vagabond...", "Vous allez prendre une rouste !"
    };



    // 1.Sujet
    // 2.Verbe
    // 3.COI
    // 4.COD
    // 5.Subordonnée

    // question ?
    // 1.Elle	2.a montré	3.à ses amis	4.le chemin	5. qui mène à sa maison ?
    // réponse 
    // 1.Elle 


    [TextArea(5, 10)]
    public string[] sentences;

    void Start()
    {

        dialogueSystem = FindObjectOfType<DialogueSystem>();
        Sexe = GetSexe();
        Age =  GetAge();
        Peuplade = GetPeuplade();
        Metier = GetMetier();
        Taille = GetTaille();
        Poids = GetPoids();

        Force = GetForce();
        Agilite = GetAgilite();
        Endurance = GetEndurance();
        Intelligence = GetIntelligence();

        Charme = GetCharme();
        Alignement = GetAlignement();
        Reputation = GetReputation();
        Personnalite_process = GetPersonnalite_process();
        Morale = GetMorale();

        RelationAvecJoueur = GetRelationAvecJoueur();

        FindObjectOfType<Livings>().add_personnage_nom(Name);

        /*Proximite = " " + GetRandomIntro()
                + " " + GetRandomQui()
                + " " + GetRandomQuand()
                + " " + GetRandomQuoi()
                + " " + GetRandomComment()
                + " " + GetRandomOu()
                + " " + GetRandomPourquoi();*/

        if (RelationAvecJoueur > 50)
        {
            Proximite = "[" + RelationAvecJoueur + "] " + GetRandomProximiPositif();
        } else
        {
            Proximite = "[" + RelationAvecJoueur + "] " + GetRandomProximiNegatif();
        }
        

        Quete = " " + GetRandomQui()
                + " " + GetRandomQuand()
                + " " + GetRandomQuoi_Quete()
                + " " + GetRandomOu()
                + " " + GetRandomPourquoi_Quete();

        Rumeur = " " + GetRandomIntro()
                + " " + GetRandomQui()
                + " " + GetRandomQuand()
                + " " + GetRandomQuoi()
                 + " " + GetRandomComment()
                + " " + GetRandomOu()
                + " " + GetRandomPourquoi();

        sentences[1] = Quete;
        sentences[2] = Proximite;
        sentences[3] = Rumeur;
    }

    public string GetRandomNom()
    {
        return noms[Random.Range(0, noms.Length)];
    }

    public string GetRandomPrenomMasculin()
    {
        return prenoms_masculins[Random.Range(0, prenoms_masculins.Length)];
    }

    public string GetRandomPrenomFeminin()
    {
        return prenoms_feminins[Random.Range(0, prenoms_feminins.Length)];
    }

    public string GetRandomIntro()
    {
        return intro[Random.Range(0, intro.Length)];
    }


    public string GetRandomQui()
    {
        Qui = Random.Range(0, 100);
        if (Qui >= 50)
        {
            return qui[Random.Range(0, qui.Length)];
        }
        else
        {
            resultat = GetRandomPersonnageExistant();
            return resultat;
        }
    }

    public string GetRandomQuand()
    {
        return quand[Random.Range(0, quand.Length)];
    }

    public string GetRandomQuoi()
    {
        return quoi[Random.Range(0, quoi.Length)];
    }

    public string GetRandomQuoi_Quete()
    {
        return quoi_quete[Random.Range(0, quoi_quete.Length)];
    }

    public string GetRandomComment()
    {
        return comment[Random.Range(0, comment.Length)];
    }


    public string GetRandomOu()
    {
        return ou[Random.Range(0, ou.Length)];
    }

    public string GetRandomPourquoi()
    {
        return pourquoi[Random.Range(0, pourquoi.Length)];
    }

    public string GetRandomPourquoi_Quete()
    {
        return pourquoi_quete[Random.Range(0, pourquoi_quete.Length)];
    }

    public string GetRandomProximiPositif()
    {
        return proximiPositif[Random.Range(0, proximiPositif.Length)];
    }

    public string GetRandomProximiNegatif()
    {
        return proximiNegatif[Random.Range(0, proximiNegatif.Length)];
    }

    public string GetRandomPersonnageExistant()
    {
        string[] list = FindObjectOfType<Livings>().list_nom.ToArray();
        return list[Random.Range(0, list.Length)];
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            /*Quete = " " + GetRandomIntro()
                + " " + GetRandomQui()
                + " " + GetRandomQuand() 
                + " " + GetRandomQuoi()
                + " " + GetRandomComment()
                + " " + GetRandomOu() 
                + " " + GetRandomPourquoi();*/

            /*sentences[1] = Quete;*/



            if (RelationAvecJoueur > 50)
            {
                Proximite = "[" + RelationAvecJoueur + "] " + GetRandomProximiPositif();
            }
            else
            {
                Proximite = "[" + RelationAvecJoueur + "] " + GetRandomProximiNegatif();
            }


            sentences[2] = Proximite;
        }






        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<Livings>().add_quete(Quete);

            int multiplicateur = 1;

            if (Alignement == "Loyal Bon") { multiplicateur = 1; }
            if (Alignement == "Loyal Neutre") { multiplicateur = 1; }
            if (Alignement == "Loyal Mauvais") { multiplicateur = 2; }
            if (Alignement == "Neutre Bon") { multiplicateur = 1; }
            if (Alignement == "Neutre strict") { multiplicateur = 0; }
            if (Alignement == "Neutre Mauvais") { multiplicateur = 3; }
            if (Alignement == "Chaotique Bon") { multiplicateur = 4; }
            if (Alignement == "Chaotique Neutre") { multiplicateur = 5; }
            if (Alignement == "Chaotique Mauvais") { multiplicateur = 6; }

            if (Personnalite_process == "Rêveur") {
                if (script.MessageEnCours.Contains("11")) 
                { 
                    RelationAvecJoueur = RelationAvecJoueur + (4);
                    print("11");
                }
                if (script.MessageEnCours.Contains("12")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("13")) { RelationAvecJoueur = RelationAvecJoueur - (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("14")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("15")) { RelationAvecJoueur = RelationAvecJoueur - (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("16")) { RelationAvecJoueur = RelationAvecJoueur + (3 * multiplicateur); }
                if (script.MessageEnCours.Contains("17")) { RelationAvecJoueur = RelationAvecJoueur + (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("18")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (reveur.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur + (1 * multiplicateur); }
                if (travailleur.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur - (1 * multiplicateur); }
            }

            if (Personnalite_process == "Rebelle")
            {
                if (script.MessageEnCours.Contains("11")) { RelationAvecJoueur = RelationAvecJoueur - (4); }
                if (script.MessageEnCours.Contains("12")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("13")) { RelationAvecJoueur = RelationAvecJoueur + (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("14")) { RelationAvecJoueur = RelationAvecJoueur - (8 * multiplicateur); }
                if (script.MessageEnCours.Contains("15")) { RelationAvecJoueur = RelationAvecJoueur - (4 * multiplicateur); }
                if (script.MessageEnCours.Contains("16")) { RelationAvecJoueur = RelationAvecJoueur - (3 * multiplicateur); }
                if (script.MessageEnCours.Contains("17")) { RelationAvecJoueur = RelationAvecJoueur - (10 * multiplicateur); }
                if (script.MessageEnCours.Contains("18")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (rebelle.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur + (1 * multiplicateur); }
                if (empathique.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur - (1 * multiplicateur); }
            }

            if (Personnalite_process == "Promoteur")
            {
                if (script.MessageEnCours.Contains("11")) { RelationAvecJoueur = RelationAvecJoueur + (2); }
                if (script.MessageEnCours.Contains("12")) { RelationAvecJoueur = RelationAvecJoueur + (4 * multiplicateur); }
                if (script.MessageEnCours.Contains("13")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("14")) { RelationAvecJoueur = RelationAvecJoueur - (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("15")) { RelationAvecJoueur = RelationAvecJoueur + (3 * multiplicateur); }
                if (script.MessageEnCours.Contains("16")) { RelationAvecJoueur = RelationAvecJoueur - (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("17")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("18")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (promoteur.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur + (1 * multiplicateur); }
                if (perseverant.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur - (1 * multiplicateur); }
            }

            if (Personnalite_process == "Empathique")
            {
                if (script.MessageEnCours.Contains("11")) { RelationAvecJoueur = RelationAvecJoueur + (3); }
                if (script.MessageEnCours.Contains("12")) { RelationAvecJoueur = RelationAvecJoueur + (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("13")) { RelationAvecJoueur = RelationAvecJoueur - (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("14")) { RelationAvecJoueur = RelationAvecJoueur + (0 * multiplicateur); }
                if (script.MessageEnCours.Contains("15")) { RelationAvecJoueur = RelationAvecJoueur - (3 * multiplicateur); }
                if (script.MessageEnCours.Contains("16")) { RelationAvecJoueur = RelationAvecJoueur + (8 * multiplicateur); }
                if (script.MessageEnCours.Contains("17")) { RelationAvecJoueur = RelationAvecJoueur + (4 * multiplicateur); }
                if (script.MessageEnCours.Contains("18")) { RelationAvecJoueur = RelationAvecJoueur + (6 * multiplicateur); }
                if (empathique.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur + (1 * multiplicateur); }
                if (rebelle.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur - (1 * multiplicateur); }
            }

            if (Personnalite_process == "Travailleur")
            {
                if (script.MessageEnCours.Contains("11")) { RelationAvecJoueur = RelationAvecJoueur - (2); }
                if (script.MessageEnCours.Contains("12")) { RelationAvecJoueur = RelationAvecJoueur - (4 * multiplicateur); }
                if (script.MessageEnCours.Contains("13")) { RelationAvecJoueur = RelationAvecJoueur - (8 * multiplicateur); }
                if (script.MessageEnCours.Contains("14")) { RelationAvecJoueur = RelationAvecJoueur + (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("15")) { RelationAvecJoueur = RelationAvecJoueur + (4 * multiplicateur); }
                if (script.MessageEnCours.Contains("16")) { RelationAvecJoueur = RelationAvecJoueur - (8 * multiplicateur); }
                if (script.MessageEnCours.Contains("17")) { RelationAvecJoueur = RelationAvecJoueur - (10 * multiplicateur); }
                if (script.MessageEnCours.Contains("18")) { RelationAvecJoueur = RelationAvecJoueur - (6 * multiplicateur); }
                if (travailleur.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur + (1 * multiplicateur); }
                if (reveur.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur - (1 * multiplicateur); }
            }

            if (Personnalite_process == "Persévérant")
            {
                if (script.MessageEnCours.Contains("11")) { RelationAvecJoueur = RelationAvecJoueur - (6); }
                if (script.MessageEnCours.Contains("12")) { RelationAvecJoueur = RelationAvecJoueur - (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("13")) { RelationAvecJoueur = RelationAvecJoueur - (4 * multiplicateur); }
                if (script.MessageEnCours.Contains("14")) { RelationAvecJoueur = RelationAvecJoueur + (10 * multiplicateur); }
                if (script.MessageEnCours.Contains("15")) { RelationAvecJoueur = RelationAvecJoueur + (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("16")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (script.MessageEnCours.Contains("17")) { RelationAvecJoueur = RelationAvecJoueur - (6 * multiplicateur); }
                if (script.MessageEnCours.Contains("18")) { RelationAvecJoueur = RelationAvecJoueur + (2 * multiplicateur); }
                if (perseverant.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur + (1 * multiplicateur); }
                if (promoteur.Any(w => script.MessageEnCours.Contains(w)) == true) { RelationAvecJoueur = RelationAvecJoueur - (1 * multiplicateur); }
            }



        }
        /* Vector3 Pos = Camera.main.WorldToScreenPoint(NPCCharacter.position);
         Pos.y += 175;
         ChatBackGround.position = Pos;*/
    }

    public void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<NPC>().enabled = true;
        FindObjectOfType<DialogueSystem>().EnterRangeOfNPC();
        currentNPCName = gameObject.name;

        if ((other.gameObject.tag == "Player") && Input.GetKeyDown(KeyCode.F))
        {
            /*print("F and Player collision");*/
            this.gameObject.GetComponent<NPC>().enabled = true;
            dialogueSystem.Names = Name;
            dialogueSystem.dialogueLines = sentences;
            FindObjectOfType<DialogueSystem>().NPCName();
        }

        if ((other.gameObject.tag == "Player"))
        {
            this.gameObject.GetComponent<NPC>().enabled = true;
            try
            {
                dialogueSystem.Names = Name;
                dialogueSystem.dialogueLines = sentences;
                FindObjectOfType<DialogueSystem>().Proximite();
            } 
            catch (NullReferenceException e) 
            {
                /*print("...");*/
            }
        }
    }

    public void OnTriggerExit()
    {
        /*print("F and Player exit");*/
        FindObjectOfType<DialogueSystem>().OutOfRange();
        this.gameObject.GetComponent<NPC>().enabled = false;

        if (RelationAvecJoueur > 50)
        {
            Proximite = "["+RelationAvecJoueur+"] " + GetRandomProximiPositif();
        }
        else
        {
            Proximite = "[" + RelationAvecJoueur + "] " + GetRandomProximiNegatif();
        }

        sentences[2] = Proximite;
    }
}

