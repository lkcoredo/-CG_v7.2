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
        "Homme des plaines", "Homme de l'Empire", "Homme du massif central", "Mi-elfe Mi-Nain", "Halfling", "Hauts Hommes", "Homme des �les"
     };

    private string[] metier = new string[] {
        "Marchand", "Aubergiste", "Servant", "Paysan", "Noble", "Bailleur", "Erudit", "Sans Emploi", "Vagabond", "Voyageur", "Aventurier", "Homme d'�glise", "Mercenaire", "Emissaire", "Forgeron", "Tisserand", "B�cheron", "Charpentier",
        "Boulanger", "B�tisseur"
     };


    private string[] alignement = new string[] {
        "Loyal Bon", "Loyal Neutre", "Loyal Mauvais", "Neutre Bon", "Neutre strict", "Neutre Mauvais", "Chaotique Bon", "Chaotique Neutre", "Chaotique Mauvais"
     };

    private string[] personnalite_process = new string[] {
        "R�veur", "Rebelle", "Promoteur", "Empathique", "Travailleur", "Pers�v�rant"
     };

    private string[] reveur = new string[] {

        "",	">:(",	"8|",	":@",	"'",	"*effleurer*",	"*regarder au loin*",	"*regard*",	"je vous en prie",	"prier",	"croire",	"*regarder en l'air*",	
        "*regarder dans les yeux*",	"*renifler*",	"esp�rer",	"solitude",	"sentiment",	"un jour",	"peut �tre",	"beau",	"R�fl�chissez",	"parlons-en",	
        "je ne sais pas",	"que",	"lait",	"id�aliste",	"distrait",	"utopiste",	"philosophe",	"contemplatif",	"m�lancolique",	"�veill�",	"lunaire",	"po�te",	
        "r�veusement",	"solitaire",	"visionnaire",	"insouciant",	"pensif",	"po�tique",	"songeur",	"soucieux",	"penseur",	"absorb�",	"abstrait",	"chim�rique",	
        "contemplateur",	"enthousiaste",	"m�ditatif",	"Pierrot",	"pr�occup�",	"sentimental",	"imaginatif",	"lucidit�",	"romanesque",	"romantique",	
        "ind�cis",	"na�f",	"r�ver",	"laisse",	"sombre",	"absent",	"ail�",	"assembleur de nu�es",	"chavirer",	"dans les nuages",	"devin",	"�berlu�",	
        "�cervel�",	"�tourdi",	"�tourdir",	"�vaporer",	"fain�ant",	"id�alisateur",	"id�ologue",	"illuminer",	"imprudent",	"inattentif",	"inconsid�r�",	
        "ing�nu",	"innocent",	"irr�fl�chi",	"langoureux",	"l�ger",	"occuper",	"pelleteux de nuages",	"proph�te",	"recueilli",	"r�vasseur",	"songe - creux",	
        "sp�culatif",	"r�ve",	"imagine",	"pense"

   };

    private string[] rebelle = new string[] {
     
        ":'D",	":D",	":P",	"8x",	"!",	":)",	";)",	":~)",	"*accolade*",	"*pousser*",	"*toucher*",	"*provoquer*",	"*grimace*",	"*rire*",	
        "pas mal",	"�a roule",	"super",	"g�nial",	"fun",	"acceptable",	"fou",	"incroyable",	"tordu",	"c'est parti",	"cool",	"r�volt�",	"insoumis",	
        "r�fractaire",	"indocile",	"indomptable",	"mutin",	"r�calcitrant",	"factieux",	"s�ditieux",	"insurg�",	"tra�tre",	"ingrats",	"princesse",	
        "m�che",	"tenace",	"d�sob�issant",	"ent�t�",	"gu�rillero",	"hostile",	"obstin�",	"opini�tre",	"perturbateur",	"r�sistant",	"dissident",	
        "joue",	"subversif",	"Homs",	"r�tif",	"r�volutionnaire",	"pi�ge",	"arm�e",	"embuscade",	"mercenaires",	"astuce",	"libert�",	"transfuge",	
        "troupes",	"arm�s",	"je suis libre",	"impropre",	"loyaliste",	"tu es libre",	"r�pression",	"libre",	"joug",	"r�siste",	"amuse toi",	"agitateur",	
        "anticonformiste",	"blasph�mateurs",	"chef",	"combattant de la libert�",	"comploteur",	"contestataire",	"contrariant",	"d�cha�n�",	"d�rangeant",	"difficile",	
        "discordant",	"dissiper",	"�garer",	"�meutier",	"ennemi",	"espi�gle",	"extr�miste",	"ferm�",	"forte t�te",	"frondeur",	"fusiller",	"hors-la-loi",	
        "imperm�able",	"incontr�l�",	"ind�pendant",	"indisciplinable",	"indisciplin�",	"in�dit",	"infranchissable",	"insensible",	"insubordonn�",	"insurrectionnel",	
        "libre",	"maquisard",	"m�content",	"conformiste",	"opposant",	"oppos�",	"perturbant",	"protestataire",	"regimbeur",	"solide",	"soumettre",	
        "sourd",	"terroriste",	"t�tu",	"trublion",	"tumultueux",	"tyran",	"vicieux",	"plaisante",	"contact"

  };

    private string[] promoteur = new string[] {
     
        ":U",	":*)",	"d",	"Q",	":",	">:)",	">:P",	"^^",	"*gifler*",	"*toucher les fesses*",	"enchant�",	"*montrer du doigt*",	"*mimer combat*",	"*immiter*",	
        "�pices",	"or",	"luxe",	"argent",	"jeux",	"vivant",	"marchand",	"manipulateur",	"sensation",	"d�fi",	"energie",	"immobilier",	"projet",	"architecte",	
        "transcription",	"ardent",	"inventeur",	"op�ron",	"ADN",	"constructeur",	"entrepreneur",	"g�ne",	"urbanisme",	"ARN",	"pr�curseur",	"investigateur",	
        "propri�taire",	"construction",	"immeuble",	"ing�nieur",	"initiateur",	"concepteur",	"cr�ateur",	"fondateur",	"investisseur",	"novateur",	"pionnier",	"sponsor",	
        "eug�nisme",	"infatigable",	"auteur",	"b�timent",	"bruxellisation",	"premier",	"promoteur immobilier",	"r�forme",	"activeur",	"agent",	"agent promoteur",	
        "�me",	"animateur",	"artisan",	"bailleur",	"b�tisseur",	"cause",	"centre",	"consensus",	"d�veloppeur",	"diffuseur",	"dirigeant",	"�dificateur",	
        "�ducateur",	"excitateur",	"fabricant",	"fauteur",	"forgeur",	"impr�sario",	"innovateur",	"inspirateur",	"instaurateur",	"instigateur",	"introducteur",	
        "jeteur",	"lanceur",	"lotisseur",	"ma�on",	"m�c�ne",	"meneur",	"moteur",	"organisateur",	"ouvrier",	"parrain",	"p�re",	"point de d�part",	"positif",	
        "programmeur",	"promotrice de r�gime",	"propagateur",	"protagoniste",	"proto - oncog�ne",	"r�alisateur",	"r�pondant",	"r�pondant d'un r�gime",	"responsable",	
        "r�v�lateur",	"s�quence",	"site promoteur",	"vulgarisateur",	"intuition",	"ch�re",	"pi�ce",	"charmant",	"charmeur"

    };

    private string[] empathique = new string[] {
    ":$",   ":'(",	"?",	":)",	"<3",	":(",	"*main*",	"*saluer*",	"*s'inqui�ter*",    "*masser*", "merci",    "*calin*",  
        "*main sur l'�paule*",	"*pleurer*",	"beaucoup",	"bienvenue",	"bonne nuit",	"bonjour",	"bonsoir",	"aimable",	"heureux",	
        "r�confort",	"chaleur",	"besoin",	"sentir",	"sympathie",	"compassion",	"empathique",	"sentiment",	"altruisme",	
        "capacit�",	"�motion",	"affectif",	"bienveillance",	"ressentir",	"contagion",	"souffrance",	"contagion �motionnelle",	
        "�prouver",	"individu",	"altruiste",	"d�tresse",	"�motionnel",	"perception",	"attitude",	"sollicitude",	"ressenti",	"alt�rit�",	
        "humain",	"percevoir",	"affect",	"bien-�tre",	"concr�te",	"comprendre",	"d�centration",	"d�clencher",	"comprend",	"diff�rencier",	
        "gentillesse",	"identification",	"ind�pendamment",	"interindividuelle",	"interlocuteur",	"intropathie",	"mental",	"miroir",	
        "partager",	"r�plicant",	"survie",	"mental",	"miroir",	"partager",	"r�plicant",	"survie",	"je comprend",	"tu as raison",	
        "raconte moi",	"dis moi",	"�a va",	"�a ne va pas",	"attendrissement",	"commis�ration",	"empathie",	"humanit�",	"piti�",	
        "sensibilit�",	"sympathie",	"d�sol�",	"escuse moi",	"pardon",	"�a va ?",	"tout va bien ?",	"chaleureux",	"nourricier",	
        "psychologue",	"parler",	"amour",	"je t'aime",    "je t'appr�cie",	"je t'ecoute",  "aime", "appr�cie"
    };

    private string[] travailleur = new string[] {
        "ok",   "%|",   ":=|",  ".",    "(",    ")",    "8|",   "*air s�rieux*",    "*interrogatif*",   "demain",   "hier", "*racler sa gorge*",    
        "*regarder autour de soi*", "*mesurer quelque chose*",  "aujourd'hui",	"quoi",	"qui",	"comment",	"o�",	"comp�tent",	"� propos",	"concentration",	
        "contr�le",	"voil�",	"factuel",	"travaille",	"ouvrier",	"salari�",	"salaire",	"travail",	"capital",	"syndicat",	"prol�tariat",	"capitaliste",	"emploi",	
        "employeur",	"productivit�",	"travailleuse",	"acharn�",	"ch�mage",	"ch�meur",	"prol�taire",	"clandestin",	"patron",	"communiste",	"honn�te",	"gr�ve",	
        "infatigable",	"Marx",	"socialisme",	"ouvri�re",	"r�mun�ration",	"socialiste",	"syndicalisme",	"autogestion",	"collectivisme",	"employ�s",	"handicap�",	
        "main-d'�uvre",   "patronat", "social",   "productif",    "qualifi�", "immigr�",  "assurance",    "journalier",   "prolo",    "anarchisme",   "capitalisme",  "consciencieux",    
        "consommateur", "embauche", "fonctionnaire",    "int�rimaire",  "minimum",  "saisonnier",   "travailler",   "z�l�", "bosseur",  "communisme",   "conf�d�ration",    
        "courageux",    "�mancipation", "frontalier",   "licenciement", "militant", "allocation",   "association",  "Bakounine",    "chantier", "labeur",   "producteur",   
        "exploitation", "fain�ants",    "ind�pendant",  "moyens de production", "Proudhon", "r�volutionnaire",  "stakhanovisme",    "syndicaliste", "agricole", "amiante",  
        "condition",    "�tudiant", "libertaire",   "marxisme", "plus - value", "secteur",  "union",    "actif",    "besoin",   "cong�",    "diligent", "employer", "�tranger", 
        "manouvrier",   "manuel",   "allons y"
     };

    private string[] perseverant = new string[] {
        ":O",   ":()",  ":'O",	":/ ",	".",	" * saluer * ",	" * s'incliner*",	"*caresser*",	"oui",	"non",	"bien sur",	"*regarder le sol*",	"*prendre sa t�te*",	
        "*main sur la bouche*",	"�videmment",	"j'aimerais ",	"je pense",	"et toi ?",	"pourquoi",	"confiance",	"croisade",	"conviction",	"surtout",	"avant tout",	
        "premierement",	"perseverant",	"patient",	"opini�tre",	"tenace",	"courageux",	"fid�le",	"obstin�",	"courage",	"continu",	"durable",	"�nergique",	
        "ferme",	"infatigable",	"constant",	"d�termin�",	"endurant",	"�prouv�",	"t�tu",	"�lever",	"r�solu",	"accentuer",	"acharn�",	"appuyer",	"assidu",	
        "attach�",	"but�",	"client",	"cons�quent",	"continuel",	"coriace",	"dur",	"ent�ter",	"fixe",	"incessant",	"inflexible",	"ininterrompu",	"malade",	
        "noble",	"permanent",	"persistant",	"r�signer",	"r�sistant",	"seconder",	"soutenir",	"sto�que",	"suivi",	"volontaire",	"z�l�",	"pi�ce",	"charmant",	
        "charmeur"
    };



    private string[] prenoms_masculins = new string[] { 
        "Olivier", "Jean", "David", "Arthur", "Bertrand", "Gotran", "Amaury", "Anthiaume", "Barth�l�mi", "Audibert", "Beno�t", "Boh�mond", "Edmond",
        "Enguerrand", "Ernaut", "Eudes", "Galaad", "Coulomb", "Garin", "Gauthier", "Gauvain", "Gibouin", "Gilemer", "Godefroy", "Gonzagues", "Gr�goire",
        "Anselme", "Aymeric", "Guilhem", "Hardouin", "Hubert", "Herchambaut", "Raymond", "Robert", "Roland", "Savari", "Tancr�de", "Thibaut", "Tristan",
        "Yvain", "Faust", "Faron", "Fulbert", "Garibald", "Gebehard", "Edwin", "Dietrich", "Dagulf", "Gotran", "Cunibert", "Crispin", "Cotron",
        "Urbain", "Conghall", "Clothaire", "Clodion", "Bertrand", "Liobbe", "Blaise", "Arichis", "Arimbert", "Closinde", "Athaloc", "Ealdight", "Beppol�ne",
        "Gripon", "Gozlin", "Gerbert", "Gandelin", "G�nialis", "Gebehard", "Fr�d�gaire", "Th�odrade", "Th�cle", "Alix", "Adovaire", "Aistulf", "Amolon",
        "Abel", "Acharie", "Adalard", "Adalb�ron", "Adalmar", "Adaloald", "Adeichis", "Adon", "Adovaire", "Aega", "Aegila", "Aeginan", "Aethaire", "Aethelstan", 
        "Agilbert", "Agile", "Agilulf", "Agobard", "Aignan", "Aimoin", "Ainmar", "Aistulf", "Alard", "Alaric", "Alboin", "Alcuin", "Aldric", "Al�th�e", "Amalaire", 
        "Amalgaire", "Armand", "Am�", "Amolon", "Anastase", "Andarchie", "Andegaire", "Animode", "Ansegis", "Ans�gis�le", "Ansoald", "Anth�miole", "Apahida", 
        "Apollinaire", "Apruncule", "Aptachaire", "Arambert", "Arbogast", "Arcadie", "Ardobert", "Ar�die", "Arichis", "Arimbert", "Arioald", "Aripert", "Armentaire",
        "Arnoul", "Aspar", "Astier", "Astreuil", "Athalaric", "Athaloc", "Athanagilde", "Athaulf", "Aunon", "Aunulf", "Aur�lien", "Ausone", "Auspice", "Austade",
        "Austremoine", "Austrin", "Autbert", "Authaire", "Autharic", "Autharis", "Avit", "Badeg�sile", "Baderic", "Baldaric", "Balduin", "Baudoin", "Baronte", 
        "Basile", "Basilisc", "Basin", "Bauto", "B�de", "B�lisaire", "Beowulf", "Beppol�ne", "Berchaire", "Berchier", "B�renger", "Beroul", "Berthachar", "Berthaire", 
        "Bertin", "Bertoald", "Beuves", "Bibracte", "Bladaste", "Blaise", "Bobol�ne", "Bod�gisile", "Bodo", "Bond", "Boniface", "Bonite", "Boson", "Bouchard",
        "Brodulf", "Brunon", "Buccelin", "Caedmon", "Cagn�ric", "Cagnoald", "Carausie", "Caribert", "Carloman", "Cassiodore", "Castin", "Caton", "Celse", "C�saire", 
        "Chadoinde", "Chairerd", "Chanao", "Chappa", "Chararic", "Chariulf", "Charivald", "Childebert", "Child�ric", "Chilp�ric", "Chlochilaic", "Chramne", "Chramnel�ne", "Chremnol�ne", "Chroce", "Chrodegang", "Chrodin", "Chrodoald", "Chuld�ric", "Chundon", "Ciucilon", "Cleph", "Clod�ric", "Clodion", "Clodoald", "Clodomir", "Clothaire", "Clovis", "Colomban", "Conan", "Conghall", "Conobre", "Constance", "Constantin", "Corbe", "Cotron", "Crispin", "Cunibert", "Cunipert", "Cyprien", "Cyrola", "Dacco", "Dadon", "Dagaric", "Dagobert", "Dagulf", "Delphin", "Dentelin", "Desid�re", "Desle", "Dietrich", "Diocl�tien", "Domigis�le", "Domitien", "Donat", "Dracol�ne", "Droctigisile", "Droctulf", "Drogon", "Druse", "Ebbon", "Eberegis�le", "Ebles", "Ebrachaire", "Ebro�n", "Ecdice", "Edbald", "Edobec", "Edwin", "Effroy", "Eginhard", "Eifel", "Eleuth�re", "Eloi", "Emery", "Ennodie", "Eptadie", "Eraric", "Erchinoald", "Erispo�", "Ermenfroi", "Ethelbert", "Eudes", "Eufraise", "Eumie", "Euphronie", "Euric", "Elric", "Eric", "Eus�be", "Euspice", "Eustaise", "Eustoche", "Eutharic", "Evrard", "Faron", "Faust", "Ferr�ol", "Flachoald", "Flodoard", "Flore", "Fortunat", "Foulque", "Fr�d�gaire", "Fridugis", "Fromond", "Frontin", "Fulbert", "Fulrad", "Gaid�ris", "Gaifier", "Galien", "Gall", "Gandelin", "Ganelon", "Garibald", "Gaugeric", "Gautier", "Gebehard", "G�limer", "G�nialis", "Gennobaude", "Genserix", "Gerbert", "Germain", "Gervold", "G�salic", "Get�", "Gewilib", "Gislemar", "Goar", "Godefroy", "God�gisile", "Godin", "Godomer", "Godopert", "Gondahar", "Gondebaud", "Gondioch", "Gondovald", "Gonthier", "Gordien", "Gotmar", "Gozlin", "Gratien", "Grifon", "Grimaud", "Grimo", "Grimoald", "Grindion", "Gripon", "Gu�rin", "Gui", "Guibert", "Guimar", "Guinemenz", "Gundichar", "Gundohine", "Gundulf", "Gunther", "Gyg�s", "Hadrien", "Haganon", "Hagn�ric", "Harding", "Harold", "Hatton", "Heiric", "Helgaud", "H�lisachar", "H�louin", "Hermanfrid", "Herm�n�gild", "Hermeuric", "H�siode", "Hilaire", "Hidebrand", "Hilduin", "Hincmar", "Honorat", "Hrolf", "Hucbald", "Hugobert", "Hunaud", "Hunoald", "lbba", "Ildibad", "Ingomer", "Injurieux", "Innocent", "Isidore", "Judicael", "Just", "Justinien", "Konrad", "Lambert", "Lantfrid", "L�ger", "Leif", "L�pide", "Leud�gis�le", "Leudovald", "Leuthaire", "Liutprand", "Liuva", "Liuvigild", "Lothaire", "Loup", "Lucain", "Lulle", "Lupicin", "Macaire", "Maclou", "Magneric", "Magnovald", "Maixent", "Mallulphe", "Mamert", "Manass�s", "Marbode", "Marcomir", "Marileif", "Marlot", "Martial", "Materne", "Mauregato", "Maximin", "M�dard", "M�robald", "Merowig", "Mesmin", "Milon", "Mummole", "Mummol�ne", "Mund�ric", "Nars�s", "Nectaire", "Nicaise", "Nigel", "Nizier", "Nomino�", "Nordebert", "Notker", "Occila", "Odelric", "Odilbert", "Odilon", "Odoacre", "Odon", "Offa", "Ollon", "Omer", "Oppila", "Orderic", "Oreste", "Othon", "Pacome", "Papoul", "Paschase", "Paterne", "Paulin", "P�gase", "Pelage", "P�one", "P�pin", "Perctarit", "Ph�bade", "Philibert", "Piat", "Plato", "Pline", "Polycarpe", "Potentien", "Pr�textat", "Primat", "Procope", "Protadie", "Quintiane", "Quiriace", "Raban", "Radagaise", "Radbod", "Radelchis", "Radelgaire", "Radon", "Radulf", "Ragnacaire", "Rainfroi", "Rainon", "Rannoux", "Ratchis", "Rauching", "Reccared", "Receswinthe", "Remacle", "Renard", "Renaud", "Renier", "Reoval", "Richer", "Richomer", "Riothime", "Roccol�ne", "Rognvald", "Rollon", "Romaric", "Romulf", "Rorgon", "Roricon", "Rufin", "Rustique", "Sabaude", "Sadr�gisile", "Sagittaire", "Salomon", "Salvien", "Samo", "Saturnin", "Savary", "Savinien", "Seg�ric", "Segondin", "Seguin", "S�rotin", "Servais", "S�v�re", "S�verin", "Sicaire", "Sicard", "Sicon", "Sidoine", "Sidon", "Sigebert", "Sigebrand", "Sig�ric", "Siggon", "Sigismer", "Sigismond", "Sigulf", "Sindold", "Sisenand", "Sixte", "Solenne", "Stilicon", "Strabon", "Suger", "Sulpice", "Sunniulf", "Sunno", "Svinthila", "Syagre", "Sylvain", "Sylvestre", "Symmaque", "Symphorien", "Tefas", "T�otolon", "Teudon", "Th�odahat", "Th�odebald", "Th�odebert", "Th�odemer", "Th�od�mis", "Th�odoric", "Th�odulf", "Thibert", "Thorismond", "Thrasamund", "Totila", "Trudulf", "Ulfila", "Urbain", "Uron", "Ursin", "Vaast", "Vacandard", "Vafr�s", "Val�rien", "Venance", "Victorin", "Victrice", "Vidaste", "Virgile", "Vitig�s", "Walbert", "Walderic", "Walla", "Wallia", "Wanba", "Wandalmar", "Wandrille", "Waratton", "Warin", "Warnachair", "Wat", "Welf", "Weroc", "Werpin", "Widukind", "Willibald", "Willibrod", "Winemer", "Winfrid", "Winnoc", "Wintrion", "Wisibald", "Witeric", "Wulfoad", "Zacharie", "Zwentibold"

    };

    private string[] prenoms_feminins = new string[] {
        "Ad�laide", "Adruhic", "Aedilberge", "AelfI�de", "A�Iis", "Agleberthe", "Agn�s", "Albofl�de", "Alchima", "Ali�nor", "Alix", 
        "Altildis", "Amalaberge", "Amalasonthe", "Ansefl�se", "Ansegis�le", "Ar�gonde", "Armentarie", "Arnegonde", "Arsino�", 
        "Ascyla", "Aubierge", "Aud�arde", "Audofl�de", "Audov�re", "Aur�a", "Ausgarde", "Auxtreberthe", "Austrigilde", "Basilie", "Basine", "Bathilde", "Baudenivie", "B�atrice", "Begga", "B�reng�re", "Berthe", "Berthefride", "Berthilde", "Bertrade", "Bertrude", "Bilichilde", "Blanche", "Bobila", "Brigithe", "Brunehaut", "Brugondofare", "Burngithe", "C�sarie", "Chrodi�lde", "Chunsine", "CIodosinde", "Closinde", "Clotilde", "Clotsinde", "Colombe", "Constance", "Corn�lia", "Croma", "Crona", "Cun�gonde", "Cuthburge", "D�ot�ria", "Dhuoda", "Disciola", "Ealdight", "Eanswithe", "Earcongothe", "Elvira", "Emma", "Emnechilde", "Enide", "Ermengarde", "Ermentrude", "Eudoxie", "Eufrasie", "Eulalie", "Eusebia", "Fabiola", "Faileuba", "Fara", "Fausta", "Fr�d�gonde", "Galswinthe", "Gerberge", "Gertrude", "Girbalda", "Gis�le", "Gislaine", "Gisledrudis", "Gislildis", "Godelive", "Godiva", "Goisvinthe", "Gueni�vre", "Hadewich", "Hedwige", "H�loise", "Hermensente", "Herminafride", "Herrade", "Hersende", "Hidburge", "Hilda", "Hildegarde", "Hiltrude", "Hrotswitha", "lngegarde", "Ingetrude", "Ingonde", "Ir�n�e", "Judith", "Juliane", "Justina", "Jutta", "Lantechilde", "Lanthilde", "Lantilde", "Leticia", "Leuba", "Liliola", "Liobbe", "Lucia", "Magnatrude", "Mahaut", "Maloucha", "Mantie", "Marcatrude", "Marcov�fe", "Mathilde", "Maugalie", "Mechtilde", "M�lanie", "M�lisande", "M�lusine", "M�rofl�de", "Mildred", "Mil�sine", "Morgane", "Muriel", "Nantechilde", "Nanthilde", "Nantilde", "Olga", "Orengarde", "Osburge", "Papianille", "Pappol�ne", "Paula", "P�lagie", "P�tronille", "Philippa", "Piacidie", "Placidine", "Plectrude", "Radegonde", "Ragnetrude", "Regelindis", "Rita", "Rogneda", "Rothilde", "Salaberge", "Septimine", "Sibylle", "Sichilde", "Sophicie", "Suanahilde", "Syre", "Tecla", "Telchilde", "T�odechilde", "Tetradie", "Tetta", "Th�cle", "Th�odechilde", "Th�odelinde", "Th�odrade", "Th�ophane", "Urraca", "V�n�rande", "Vera", "Viviane", "Vulf�gonde", "Vultetrade", "Wanda", "Wisigarde"
    };

    private string[] noms = new string[] { 
        "de Clairefontaine ", "de Courtelande ", "le Taciturne ", "Dent-de-Loup", "de Montbard", "de Neuville",
        "d'Aiglemont", "de B�n�vent  ", "Pelletier", "Courtois", "Roux", "Le Blond",
        "de Fiercastel", "de Blancmoustier ", "Cabrera", "M�tivier", "Chauvin", "Delfosse",
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
        "J'ai entendu dire que ", "Il parait que ", "J'ai ou�e dire ", "Ecoutez moi, ", "A ce propos, ", "J'ai une id�e pour vous, ",
        "", "Prenez note, ", "Attendez, ", "Alors justement, ", "Ah oui, ", "�a me fait penser, ",
        "J'ai une mission pour vous, ", "J'ai quelque chose pour vous, ", "Oui tout � fait, ", "Tendez l'oreille, ", "", "",
        "", "", "", "", "", "", "j'ai entendu dire quelque chose d'�trange, ", "j'ai ou�e dire quelque chose de dingue, ", "il parait... attendez vous n'�tes pas pr�t...", 
        "Vous savez ce qui se dit ?", "Approchez j'ai un secret pour vous !", " Vous ne connaissez pas la nouvelle ?", 
        "Vous allez halluciner de ce que je vais vous dire !", "Pr�parez vous au pire", "Ecoutez moi bien", "J'ai entendu des rumeurs...", 
        "Il court des bruits..", "Tout le monde en parle !", "C'est la nouvelle du moment !", "Vous n'allez pas me croire", "C'�tait sur toutes les bouches."
    };

    //qui
    private string[] qui = new string[] {
        "un troll", "des gobelins", "un vampire", "des loups", "un ours", "des orques", "un g�ant", "un dragon", "une vouivre", "le chef des bandits", 
        "un bandit", "un truand", "un mendiant", "un assassin", "un spectre", "un esprit", "un homme malveillant", "un sorcier", "une sorci�re", 
        "un d�mon", "des rats", "des araign�es", "des monstres affreux", "des choses ignobles", "une �trange pr�sence", "le voisin", "une femme du village", 
        "le pr�tre", "le chef du village", "le chasseur", "le cur�e", "ma voisine", "mon voisin", "ma m�re", "mon fils", "la m�re du chef du village", 
        "le p�re du petit grigory", "le boucher", "le fils du boulanger", "le boulanger", "la boulang�re", "le tavernier", "un soldat de la garde", "un p�cheur", 
        "une prostitu�", "une fille de petite vertu", "un chat", "un chien", "un lapin", "un druide", "un moine", "l'herboriste", "un espion", 
        "le diacre", "un m�decin", "un astrologue", "le bailli", "l'homme le plus riche du village", "tresorier", "le marquis", "le seigneur", 
        "le baron", "le vicomte", "le vicaire", "le doyen", "le comte", "l'eveque", "l'abbe", "l'intendant", "le roi", "le prince", "le fils de l'empereur", 
        "l'�lu de la proph�tie", "un elfe", "un nain", "un humain", "une f�e", "une demi-homme", "un demi-elfe", "un aventurier", "un voyageur", 
        "un type pas net", "un dr�le de voyageur", "un lutin", "un homme arbre", "un centaure", "un minotaure", "un cheval", "un �trange marchand", "un musicien"
    };

    //quand
    private string[] quand = new string[] {
        "l'autre soir", "il ya quelques temps", "hier soir ", "ce matin", "tout � l'heure", "il y a quelques semaines",
        "il y a 10 minutes donc tr�s vite, d�p�chez vous...", "il y a 30 minutes", "il y a 1h", "il y a 2h", "il y a 5h", "ce soir", "� minuit", "demain", 
        "apr�s demain", "il y a une semaine", "il y a un mois", "il y a deux mois", "il y a quatre mois", "il y a six mois", "l'ann�e derni�re", "il y a 5 ans"
    };

    //quoi
    private string[] quoi = new string[] {
        "a pri� le diable", "a perdu toute sa richesse", "est devenu riche", "a �t� tu�", "a �t� viol�", "a �t� assassin�", "est amoureux", 
        "est devenu fou", "a p�t� les plombs", "a tu� toute sa famille", "a massacr� tout une ville", "a perdu son dentier", "a �t� excommuni�", 
        "s'est promen� nu", "a mang� une pomme empoisonn�e", "a danser sous la lune", "dort pied nu", "a �t� banni", "a gagn� le grand prix", 
        " a d�couvert un dragon", "a invent� la poudre", "a d�couvert le feu", "a chang� tout un village en pierre", "a mis feu � la grange", 
        "a fait tomber tous les criminelles de la r�gion", "garde une pierre tr�s pr�cieuse", "a invoqu� un d�mon !", "a annonc� la fin du monde", 
        "a vu un nain sans barbe !", "a r�volutionn� la science", "a perdu ses clefs", "a vendu sa maison", "est � la rue", 
        "est devenu sans domicile fixe", "�tait bourr�", "a vomi dans l'�glise", "a d�f�quer dans la mairie", "sent mauvais", 
        "pu le fromage pourri", "a trouv� un tr�sor", "a d�terr� un manuscrit qui date de 50 ans", "court tous les soirs", 
        "ne mange jamais de l�gumes !", "ne mange jamais de viande", "se nourrit exclusivement de poisson"
    };

    //quoi_quete
    private string[] quoi_quete = new string[] {
        "a voulu me tuer",
        "m'a cambriol�",
        "m'a insult�",
        "m'a arnaqu�",
        "me doit de l'argent"
    };

    //comment
    private string[] comment = new string[] {
        "tout doucement", "d'un coup", "sans crier gare", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", ""
    };

    //ou
    private string[] ou = new string[] {
        "dans la for�t", "dans les �go�ts", "dans le champs", "cach� dans la ville", "dehors", "je ne sais ou !", "� l'est", "� l'ouest", 
        "au sud", "au nord", "quelque part", "dans un trou", "dans une grotte", "dans une ruine", "dans un cimetierre", "dans les montagnes"
    };

    //pourquoi
    private string[] pourquoi = new string[] {
        "cela terrorise les villageois", "nous avons eu des victimes", "c'est g�nant", "c'est effrayant", 
        "mon fr�re est mort � cause de cette menace", "ma soeur est morte...", "j'ai perdu ma m�re � cause de ce genre de montre", 
        "j'ai perdu mon p�re � cause de ce genre de montre", "j'ai perdu ma tante hier et je soup�onne �a", 
        "j'ai perdu mon oncle et je pense que c'est li�", "j'ai perdu ma famille, c'est terrible... ce fils de p... escusez moi je suis sous le choc vous comprenez...", 
        "j'ai peur", "tout le monde a peur", "nous avons peur", "la menace grandit", "la menace s'est infiltr� partout !", "ils sont partout !", 
        "je suis terrifi�", "�a devient probl�matique", "tout est devenu si sombre ces derniers jours � cause de cette menance", 
        "j'ai l'impression que je vais mourrir", "j'ai vu mon destin funeste approcher � grands pas...", 
        "�a presence me fatigue !", "j'en ai marre", "c'est ce qu'il faut faire !", "le chef l'a d�cid�", "les paysans en ont marre !", 
        "j'ai cru le voir dans mes toilettes ce matin", " je l'ai trouv� dans mon bain !", "il a assombri le ciel !", 
        "la magicienne du village m'a pr�dit que cette menace me tuera demain", "ma vie est en danger", "je me suis fait vol� tout ce que j'avais", 
        "mes affaires disparaissent !", "j'ai perdu un projet pr�cieux et ce n'est pas anodin !", "Je soup�onne ces montres de me voler mes �conomies", 
        "je soup�onne ce genre de malotru de piquer mes r�serves...", "j'en peux plus !", "je ne veux plus les voir !", 
        "je veux en finir avec eux", "j'ai envie aha !"
    };

    //pourquoi_quete
    private string[] pourquoi_quete = new string[] {
        ", aidez moi s'il vous plait, je vous promet une r�compense !"

    };

    //proxi positif
    private string[] proximiPositif = new string[] {
        "Messire ?", "Tout va bien ?", "Comment allez vous ?", "N'h�sitez pas si vous avez besoin de quelque chose", "Faites attention � vous", "Attention !", "Ecoutez...", "Soyez attentif !",
        "pardon ?", "Vous avez dit quelque chose ?", "Partagez moi vos pens�es", "Quelque chose vous tracasse", "Je vous attends", "Dites moi quelque chose", "Vous avez dit quelque chose ?", "hum hum",
        "Mes hommages messire", "Vous souhaitez quelque chose ?", "un instant...", "� tiens que voulez vous ?", "je vous demande pardon ?", "Vous revoil� ?", "Qu'est-ce que vous souhaitez ?",
        "Vous avez essay� de me parler ?", "Oui ?", "Plait-il ?", "Vous avez un message � me faire passer ?", "Qu'est-ce qui vous am�ne de si bon matin ?", "Vous avez quelque chose � me dire vous !",
        "Je vous en prie discutons !", "Venez me parler un peu", "N'h�sitez pas si vous avez besoin de parler", "Je sens que quelque chose vous tracasse", "Essayez de me parler, vous allez voir je ne mord pas",
        "Allez je vous en prie parlez moi !", "Venez � moi", "Crachez le morceau !", "Il vous faut quelque chose", "Je crois que vous avez envie de me parler je me trompe ?", "Qu'est-que vous faites ?",
        "A tiens vous vous promnez comme moi ?", "Vous avez oubli� quelque chose ?", "Que cherchez vous ?", "Vous �tes bien press� !", "Il fait beau aujourd'hui non ?", "Vous aimez vous promener dans la nature ?",
        "c'est agr�able de se promener aujourd'hui", "Je trouve qu'il fait beau, pas vous ?", "On se sent bien ici non ?", "J'ai pr�parer un bon repas ce soir", "Vous n'avez pas vu pass� un chien par hasard?",
        "C'est fou comme le temps passe si vite !", "je n'en peux plus je suis extenu� !", "�a se rafraichit le temps vous ne trouvez pas ?", "C'est incroyable, je l'avais pos� ici tout � l'heure",
        "Qu'est-ce que c'est ennuyeux par ici", "Je ne sais pas quoi faire de mon temps libre", "C'est dingue comme le temps change sans arr�t ces jours-ci"
    };

    //proxi negatif
    private string[] proximiNegatif = new string[] {
        "Eloignez vous de moi", "Imb�cile !", "Regardez ou vous posez les pieds, merci !", "Qu'est-ce que vous me voulez ?", "Allez vous en !", "Hein ?", 
        "D�gagez moi le passage", "Encore vous ?", "�a suffit de vous maintenant", "Je ne peux plus vous voir", "Qu'est-ce qui fait encore l� celui l� !", "C'est qui ce type ?", 
        "Qu'est-ce qui nous veut celui l� ?", "Touriste...", "J'ai pas le temps de discuter", "foutez moi le paix!", "j'en ai d�j� marre de vous", "c'est pas croyable comme on s'ennuie !",
        "Foutez moi le camp!", "J'aimerais �tre tranquille c'est possible ?", "Laissez moi, j'ai besoin de r�fl�chir...", "Je ne peux pas penser avec vous dans les parages",
        "Du balais !", "Oust !", "C'est pas vrai �a ! Je n'ai pas besoin d'un cr�tin dans les parages...", "Attention...", "Vous devriez vous m�fier...", "Sortez de mon champs de vision",
        "Hors de ma vue !", "Circulez!", "Fichez moi la paix pour de bon !", "Voil� un mauvais pr�sage..", "Vous en faites une de ces t�tes...", "Ne m'approchez pas", "Pas un pas de plus !",
        "Je n'ai pas besoin de subir votre stupidit�", "Loin, partez loin", "Qu'est- qu-il y a ?", "Il veut quoi lui ?", "Sortez de ma propri�t� !", "J'ai besoin d'air", "c'est quoi �a encore ?",
        "Vous croyez que j'ai que �a � faire de vous �couter", "C'est pas possible, encore vous ?", "D�gage le pitre", "Bouffon...", "Vous ne devriez pas trainer par ici", "Je ne vous aime pas",
        "Allez voir ailleurs si j'y suis !", "Vous me prenez pour un imb�cile ?", "Qu'est-ce que j'ai dit ?", "Non, pas aujourd'hui", "Du balais bon sang !", "Nom de dieu !", "Il ne fait pas bon de trainer ici",
        "rentrez chez vous", "rentrez chez votre m�re", "Vous n'avez pas mieux � faire que d'ennuyeux les honn�tes gens ?", "Je n'ai vraiment pas besoin de �a aujour'dhui...", "Sortez d'ici",
        "N'essayez m�me pas", "N'h�sitez pas � d�guerpir", "Attention je peux me facher", "Y'en a marre...", "Quoi ???", "Oh tu m'�coutes ?", "Passe ton chemin !", "Batard..", "Sale voleur !",
        "Je suis sur que vous �tes un vagabond !", "Vagabond...", "Vous allez prendre une rouste !"
    };



    // 1.Sujet
    // 2.Verbe
    // 3.COI
    // 4.COD
    // 5.Subordonn�e

    // question ?
    // 1.Elle	2.a montr�	3.� ses amis	4.le chemin	5. qui m�ne � sa maison ?
    // r�ponse 
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

            if (Personnalite_process == "R�veur") {
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

            if (Personnalite_process == "Pers�v�rant")
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

