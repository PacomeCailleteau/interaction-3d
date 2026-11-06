
# Interaction 3D : techniques de manipulation


**Pacôme CAILLETEAU**
FIL A3 Front - IMT Atlantique
Cours RX - Réalité virtuelle et interactions 3D
5 novembre 2026

Dépôt : [github.com/PacomeCailleteau/interaction-3d](https://github.com/PacomeCailleteau/interaction-3d)


# 1. Prise en main et référence initiale


J’ai utilisé un Meta Quest 2 avec les contrôleurs Touch. Le projet fourni a été ouvert avec Unity 6000.3.27f1, en conservant XRI 3.3.0, OpenXR 1.16.0 et Input System 1.17.0. La scène Interaction est construite pour Android avec OpenXR et le rendu Multi Pass.


| Essai de deux minutes | Étages complets |
| --- | --- |
| Premier essai | 3 |
| Deuxième essai et meilleur score | 4 |


Je préfère le déplacement continu au joystick pour cette tâche. Il permet d’ajuster progressivement ma position près des générateurs et de la tour. La téléportation m’a paru plus rapide, mais je la trouvais déstabilisante. À l’arrivée, je perdais mes repères et je devais me réorienter.

![Saisie directe dans Unity. Le chrono démarre au premier bloc et Reset reste accessible.](captures/etape-3-saisie-centre.png)


# 2. Changer de technique sur chaque main


Controller Manager est présent sur les deux contrôleurs. Chaque technique est un enfant direct du contrôleur et porte le tag ControllerMode. B change le mode droit et Y le mode gauche. Le script désactive les autres modes avant d’activer le suivant.

J’ai utilisé B et Y pour changer de technique sur chaque main. Un seul mode reste actif par contrôleur et le cycle revient au premier après le dernier. Les modes temporaires de préparation ont été retirés une fois les techniques ajoutées.

Étape intermédiaire : modes temporaires dans la hiérarchie et référence Switch Mode du contrôleur droit.

![Changement de mode, étape intermédiaire](captures/etape-2-changement-de-mode.png)

J’ai ajouté six modes sur chaque contrôleur. Pour la main gauche, j’ai remplacé les références aux actions de droite par les actions XRI Left et réglé la latéralité à gauche.


| Ordre | Mode |
| --- | --- |
| 1 | Saisie directe |
| 2 | Rayon fixe bleu |
| 3 | Rayon réglable vert |
| 4 | Rayon orange avec Force Grab |
| 5 | Near Far violet, à distance |
| 6 | Near Far jaune, rappel à la main |


Configuration finale : six modes sous chaque contrôleur, dans le même ordre.

![Hiérarchie finale des deux contrôleurs](captures/etape-6-deux-mains.png)

Les rayons excluent la couche Teleport et l’interaction UI est désactivée. Le masque physique du raycast et les couches d’interaction XRI sont deux filtres différents. Les blocs doivent être autorisés par les deux.

Difficulté rencontrée : le joystick peut manipuler un bloc et piloter la locomotion en même temps. Les commandes concurrentes sont suspendues pendant la manipulation, puis restaurées après le dernier relâchement concerné.


# 3. Saisir au point de contact


J’ai dupliqué les deux générateurs et les deux prefabs pour garder la saisie d’origine disponible. Les copies sont bleu clair et jaune orangé. Chaque nouveau générateur référence son prefab et le même chronomètre.

Sur les copies, Use Dynamic Attach calcule l’attache lors de la prise. Match Position utilise le point de contact, Match Rotation conserve l’orientation au moment de la prise et Snap To Collider Volume limite l’attache au volume du bloc. Les options sont activées dans la configuration retenue.

![Bloc d’origine : le centre est ramené dans la main.](captures/etape-3-saisie-centre.png)

![Bloc dynamique : la prise reste près de l’extrémité.](captures/etape-3-saisie-contact.png)

Je préfère la saisie au point de contact, car le bloc reste tenu à l’endroit où je l’attrape. En le prenant par une extrémité, je peux le positionner sans devoir autant avancer les bras.

Cette différence est surtout utile pour replacer un bloc sous ceux qui sont déjà empilés. Avec la saisie d’origine, le bloc se recentre brusquement dans la main. Ce déplacement peut heurter les blocs voisins et faire tomber une partie de la tour. La saisie au point de contact permet de le reprendre sans ce décalage.

Le choix de la prise reste important. Tourner le contrôleur fait pivoter le bloc autour du point choisi. Une prise à l’extrémité donne de la portée, mais l’autre bout du bloc décrit un mouvement plus large. Il faut en tenir compte près des blocs déjà posés.

Dans le casque, j’ai pu créer des blocs avec les quatre générateurs, les saisir et les relâcher. Les deux nouveaux blocs restent tenus au point où je les prends. Reset supprime bien les blocs créés.


# 4. Comparer les rayons virtuels


Les trois rayons utilisent la gâchette sous l’index et les mêmes filtres. Le rayon permet d’atteindre les générateurs sans s’approcher. La saisie directe reste plus simple pour placer un bloc proche, car son mouvement suit directement celui de la main.


| Variante | Force Grab | Attache au joystick |
| --- | --- | --- |
| Bleu | Non | Non |
| Vert | Non | Distance et rotation |
| Orange | Oui | Distance et rotation |


![Bleu : distance de saisie fixe.](captures/etape-4-rayon-bleu.png)

![Vert : réglage de distance et de rotation.](captures/etape-4-rayon-vert.png)

![Orange : survol d’un bloc éloigné.](captures/etape-4-rayon-orange.png)

![Force Grab ramène le bloc à la main.](captures/etape-4-force-grab.png)

Je préfère le rayon orange. Le bloc vient directement à la main, puis je peux l’éloigner légèrement au joystick pour le placer. Le vert arrive en deuxième position. Le réglage est pratique, mais ramener un bloc saisi de loin prend du temps. Le bleu est le moins pratique. Sans réglage de distance, un bloc pris trop loin est difficile à placer sans se déplacer.

Force Grab réduit le transport à distance, mais change brusquement la position du bloc lors de la prise. Manipulate Attach Transform permet d’ajuster ensuite la distance et la rotation. Avec le rayon orange, j’ai obtenu 5 puis 7 étages, ce qui en fait mon meilleur résultat parmi les trois rayons.


# 5. Near Far : proche et lointain


J’ai ajouté deux modes Near Far à partir du prefab fourni. Ils permettent une saisie au contact et une sélection à distance. Far Attach Mode = Far conserve le bloc à distance dans le mode violet. Far Attach Mode = Near le ramène à la main dans le mode jaune.

![Violet : maintien du bloc à distance.](captures/etape-5-violet-distance.png)

![Violet : manipulation au joystick.](captures/etape-5-violet-manipulation.png)

![Jaune : survol d’un bloc éloigné.](captures/etape-5-jaune-survol.png)

![Jaune : bloc ramené à la main.](captures/etape-5-jaune-main.png)

Ma préférence dépend de ma position par rapport à la tour. Lorsque je suis loin, je préfère le violet. Je peux rapprocher, éloigner et orienter rapidement le bloc au joystick. Lorsque je suis juste devant la tour, je préfère le jaune. Je peux poser le bloc avec les mouvements du contrôleur, sans avoir besoin de réglages à distance.

Le changement de commande est sensible entre les variantes. Avec le jaune, une fois le bloc dans la main, je ne peux plus le déplacer ou le tourner à distance au joystick. C’est pratique près de la tour, mais plus contraignant quand je veux encore travailler de loin.

Je rapproche cette technique du principe hybride de HOMER présenté dans le cours : sélectionner avec un rayon, puis manipuler avec une commande liée à la main virtuelle. Near Far combine en plus une saisie proche et une saisie lointaine. Near ou Far détermine ici où reste l’objet après sa sélection.

Rapprochement avec le cours Interaction 3D, partie Manipulation, diapositives HOMER : [etiennepeillard.com/fr/slides/vr-interaction/](https://www.etiennepeillard.com/fr/slides/vr-interaction/).


# 6. Manipuler avec les deux mains


J’ai ajouté les six techniques au contrôleur gauche en adaptant les actions et la latéralité. Les deux mains peuvent tenir deux blocs distincts en même temps. Chaque bloc reste tenu par une seule main à la fois.

![Deux blocs tenus simultanément. Les modes gauche et droit se changent indépendamment avec Y et B.](captures/etape-6-deux-blocs.png)

J’ai testé la manipulation avec les deux mains en étant près de la tour. Les deux contrôleurs fonctionnent simultanément, mais dans cette situation, je préfère utiliser uniquement la main droite.

Étant droitier, je trouve Near Far avec Force Grab, représenté en jaune, plus pratique à droite pour poser les blocs délicatement et précisément. Je préfère laisser la main gauche sans manipulation pour me concentrer sur le bloc que je place.

Près de la tour, utiliser deux mains ne m’a donc pas paru plus efficace. Je suis plus à l’aise en gardant une seule main pour manipuler les blocs. J’ai obtenu 5 puis 6 étages à deux mains, contre 6 puis 8 avec Near Far jaune à droite seule.

J’ai prévu un verrou partagé pour les commandes de locomotion. Quand les deux mains utilisent le joystick pour manipuler, ces commandes restent réservées jusqu’au dernier relâchement. Cela évite qu’une main réactive le déplacement pendant que l’autre tient encore un bloc à distance.


# Bilan comparatif et état final


J’ai réalisé deux essais de deux minutes pour chaque technique. Avec la saisie directe initiale, j’ai construit 3 étages au premier essai et 4 au deuxième. Le tableau ci-dessous regroupe mes résultats et ce que je retiens des techniques testées.


| Configuration | Main utilisée | Saisie | Réglage | Essai 1 | Essai 2 | Meilleur | Ce que je retiens |
| --- | --- | --- | --- | --- | --- | --- | --- |
| Directe initiale | Droite | Centre | Saisie au contact | 3 | 4 | 4 | Simple au contact, mais le bloc se recentre dans la main. |
| Directe dynamique | Droite | Contact | Dynamic Attach | 4 | 6 | 6 | Plus pratique pour reprendre un bloc par son extrémité. |
| Rayon bleu | Droite | Contact | Force Grab non, attache fixe | 2 | 3 | 3 | Difficile à placer si le bloc a été pris trop loin. |
| Rayon vert | Droite | Contact | Force Grab non, attache réglable | 4 | 6 | 6 | Réglable, mais ramener un bloc éloigné prend du temps. |
| Rayon orange | Droite | Contact | Force Grab oui, attache réglable | 5 | 7 | 7 | Mon choix parmi les rayons. Le bloc vient à la main. |
| Near Far violet | Droite | Contact | Far Attach Mode = Far | 6 | 8 | 8 | Mon choix lorsque je suis loin de la tour. |
| Near Far jaune | Droite | Contact | Far Attach Mode = Near | 6 | 8 | 8 | Mon choix près de la tour pour poser précisément. |
| Deux mains | Gauche et droite | Contact | Mon choix près de la tour : jaune à droite | 5 | 6 | 6 | Les deux fonctionnent, mais je préfère la droite seule près de la tour. |


J’ai réalisé les essais avec un Meta Quest 2 et les contrôleurs Touch. Je préfère me déplacer au joystick pour ajuster progressivement ma position près de la tour.

**Précision, rapidité et effort.** La saisie au point de contact évite le recentrage du bloc et réduit les mouvements de bras. Le rayon donne accès aux objets éloignés, mais son intérêt dépend du contrôle de la distance. Près de la tour, je préfère Near Far jaune à droite. Loin de la tour, le violet me paraît plus pratique. L’ordre des tests et l’apprentissage peuvent influencer les résultats. Ce tableau ne suffit pas à établir qu’une technique est toujours meilleure.

**État final.** L’application permet de changer de mode sur chaque main sans reconstruire, de créer les deux couleurs, de saisir et relâcher les blocs, de manipuler avec une ou deux mains, de naviguer et de réinitialiser la tâche. Dans le casque, j’ai pu créer les blocs, les saisir avec les différentes techniques, les relâcher, utiliser les deux mains et remettre la scène à zéro. Je retiens surtout l’intérêt d’adapter la technique à ma position et au placement que je veux réaliser.
