using MyLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Stub
{
    public class StubDataManager : IPersistanceManager
    {
        public (IEnumerable<Element> elements, IEnumerable<Evenement> evenements) ChargerLesDonnées()
        {
            ObservableCollection<Element> Elements = new ObservableCollection<Element>();
            ObservableCollection<Evenement> Evenements = new ObservableCollection<Evenement>();
            Elements.Add(new Personnage("Valentine", "Jill", "Elle est experte dans le maniement des armes à feu, le crochetage de serrures et la neutralisation d'explosifs."));

            Elements.Add(new Personnage("Kennedy", "Leon Scott", "Leon semble être un jeune homme naïf avec un fort sens de la justice, et ayant pour priorité de venir en aide aux faibles."));

            Elements.Add(new Personnage("Redfield", "Claire", "Elle sait faire face à des situations imprévues grâce à une grande imagination, elle échafaude des plans extravagants mais qui sont généralement efficaces."));

            Elements.Add(new Personnage("Redfield", "Chris", "Chris Redfield a commencé sa carrière militaire en tant que pilote de l'US Air Force."));

            Elements.Add(new Personnage("Wong", "Ada", "Elle est une belle mercenaire américaine vraisemblablement d'origine chinoise, extrêmement habile en espionnage et redoutable au combat."));

            Elements.Add(new Personnage(" Aiken", "Richard", "Membre de l'équipe Bravo des S.T.A.R.S. Il agit en renfort de l'équipe. Il veille également sur la nouvelle recrue," +
                " Rebecca Chambers. Il fera tout ce qui est en son pouvoir pour protéger quelqu'un, allant même jusqu'à mettre sa vie en danger." + "" +
                " Il est empoisonné par un serpent géant (s'il est sauvé par le sérum il sera dévoré par le serpent géant). Par la suite," +
                " il sera dévoré par un requin en sauvant Chris Redfield dans le premier épisode de la série."));


            Elements.Add(new Personnage("Chambers", "Rebecca", "Membre de l'équipe Bravo des S.T.A.R.S., Rebecca est une experte en préparation et fabrication de médicaments et tient le rôle d'infirmière de l'équipe." +
            "Après la séparation du reste de son équipe partie enquêter sur des meurtres, le crash de leur hélicoptère et l'ordre de capturer Billy Coen, elle rencontra ce dernier dans un train appelé l'Ecliptic Express." +
            "Ils n'eurent pas d'autre choix que de faire équipe et d'affronter James Marcus. Rebecca se sépara de Billy et se dirige vers le manoir," +
            " point de rendez-vous de l'équipe Bravo.Elle est aurai vécu dans le manoir dans RE1 et elle s'en sortira vivante avec Jill et Chris. Elle est la seule survivante de l'équipe bravo dans l'incident du manoir."));

            Elements.Add(new Personnage("Coen", "Billy", "Ancien sous-lieutenant des Corps des Marines, il a été condamné à mort pour assassinat à l'occasion de la mort de 23 personnes." +
                " Billy est capable de manier n'importe quelle arme. Endurci par l'entraînement au sein des Marines, il est en mesure d'affronter n'importe quel monstre." +
                " Il fera équipe avec Rebecca Chambers et une fois vaincu Marcus dans sa forme finale, on le revoit plus."));

            Elements.Add(new Personnage("Dewey", "Edward", "Membre de l'équipe Bravo des S.T.A.R.S., dont il assure la sécurité d'arrière-garde." +
                " Généralement pilote, il a été le copilote de Kevin Dooley lors de la mission dans la forêt de Raccoon City. Après le crash de l'appareil," +
                " il a découvert l'Ecliptic Express dont il a examiné l'intérieur. C'est à ce moment qu'il a été mordu par un Zombie, devenant ainsi la première victime de l'équipe avant de devenir lui-même un zombie."));

            Elements.Add(new Creature("Nemesis", "Le Nemesis-T Type (Nemesis-Tyrant Type) était une troisième génération d'armes biologique de type Tyran développée par le Sixième Laboratoire d'Umbrella Europe en France" +
                " sous la direction directe du Quartier Général d'Umbrella, à travers l'utilisation de l'organisme parasite artificiel « Type NE-α »," +
                " généralement appelé « Nemesis ». Son but était de prouver qu'une créature infectée par le Virus-T puisse avoir une intelligence supérieure," +
                " des capacités de combat et une plus grande capacité de suivre les ordres sans avoir besoin d'être dirigée constamment, manipulant ainsi une grande variété d'armes.",
                Dangerosité.Très_dangereux));

            Elements.Add(new Creature("T-00",
                "Le T-103, aussi appelé communément Mr. X, est l'un des antagonistes de Resident Evil 2 (1998) et Resident Evil 2 (2019). C'est une arme biologique de catégorie Tyran." +
                "Sa mission principale est de récupérer l'échantillon de Virus-G.",
                Dangerosité.Très_dangereux));

            Elements.Add(new Creature("Tyran", "Le Tyran est un boss classique de la saga Resident Evil. Il s'agit d'une série d'armes biologiques expérimentales et produites en série," +
                " développées par Umbrella Corporation pour servir de supers soldats potentiels. Les Tyrans sont forts et vigoureux, quoiqu'un peu lents." +
                " D'un jeu à l'autre, on retrouve généralement un modèle de Tyran différent.",
                Dangerosité.Boss));

            Elements.Add(new Creature("Plaga",
                "Contrairement au Virus-t, qui transformait ses victimes en zombies écervelés, les Plagas sont des parasites qui prennent le contrôle du système nerveux des hôtes dans lesquels ils sont implantés." +
                " Les personnes infectées par ce parasite (Ganado comme Majini) deviennent beaucoup plus fortes et très résistantes à la douleur, tout en travaillant collectivement à la poursuite de leurs objectifs." +
                "D'autres effets secondaires incluent la perte complète de raisonnement — sauf chez certains sujets (qui ne sont toutefois pas en mesure de résister à la nécessité d'obéir à des ordres supérieurs) — et la pleine conformité à l’espèce de Plaga dominante.",
                Dangerosité.Dangereux));

            
            Evenement e = new Evenement("Création du virus", "Mise au point par James Marcus, Ozwell E. Spencer et Edward Ashford du virus \"précurseur\"", "laboratoire", DateTime.Parse("4/12/1966"));
            Elements.Add(e);
            Evenements.Add(e);
            e.BasculerFavoris();

            Evenement e1 = new Evenement("Umbrella", "Fondation d'Umbrella par Spencer, Ashford et Marcus. Ce dernier prend la tête du centre de formation afin de pouvoir mener tranquillement, et loin des préoccupations mercantiles de Spencer, des recherches complémentaires sur le virus précurseur.", "lieu indéterminé",DateTime.Parse("1/1/1968"));
            Elements.Add(e1);
            Evenements.Add(e1);

            Evenement[] tabEvenement = new Evenement[6];

            tabEvenement[0] = new Evenement("Virus-T", "James Marcus développe dans son laboratoire des montagnes d'Arklay un dérivé du virus précurseur : Le Virus-T. Il procédera dans les années suivantes des tests sur divers êtres vivants (y compris humains). Les tests opérés sur les sangsues sont particulièrement concluants.", "laboratoire de Marcus",DateTime.Parse("19/09/1978"));
            tabEvenement[1] = new Evenement("Assassinat de Marcus", "1988 : Spencer commandite l'assassinat de James marcus avec la complicité des anciens élèves de ce dernier, Albert Wesker et William Birkin.", "lieu indeterminé", DateTime.Parse("1/1/1988"));
            tabEvenement[2] = new Evenement("Condamnation de Coen", "1997: Le lieutenant Billy Coen en mission en Afrique refuse de tuer des civils. Cette désobéissance lui vaudra par la suite d'être interné et condamné.", "Afrique", DateTime.Parse("1/1/1998"));
            tabEvenement[3] = new Evenement("Fuite du Virus-T", "Une fuite de Virus-T a lieu dans le laboratoire du Manoir d'Arklay (spencer). Celle-ci causera la contamination et la mort de plusieurs chercheurs, notamment celle de John, petit ami d'Ada Wong","laboratoire du Manoir",DateTime.Parse("11/05/1998"));
            tabEvenement[4] = new Evenement("Disparition étrange", "Les médias de Raccoon City font mention de disparitions étranges dans les environs de la ville", "Raccon city", DateTime.Parse("19/06/1998"));
            tabEvenement[5] = new Evenement("Tests d'Umbrella", "Le siège d'Umbrella décide de procéder à des tests de leurs Armes biologiques (zombies, ...) en mettant les STARS au contact des monstres au manoir Spencer. A l'issue de ces expériences, umbrella souhaite que le laboratoire caché du manoir soient détruit (en ayant au préalable récupéré des embryons des créatures (hors Tyran).", "Manoir",DateTime.Parse("22/06/1998"));
            
            for(int i=0; i<tabEvenement.Length; i++)
            {
                Elements.Add(tabEvenement[i]);
                Evenements.Add(tabEvenement[i]);
            }
            return ((IEnumerable<Element>)Elements, (IEnumerable<Evenement>)Evenements);
        }

        public void SauvegarderLesDonnées(IEnumerable<Element> elements, IEnumerable<Evenement> evenements)
        {
            Debug.WriteLine("Sauvegarde demandée");
        }
    }
}
