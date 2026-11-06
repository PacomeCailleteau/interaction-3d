# Interaction 3D

Pacôme CAILLETEAU, FIL A3 Front.

TP RX sur les techniques de manipulation en réalité virtuelle. Le projet de départ est celui fourni par Cédric Fleury sur la [page du TP](https://www.etiennepeillard.com/fr/teaching/lab/3d-interaction/).

## Ouvrir le projet

Cloner ce dépôt, puis ajouter son dossier dans Unity Hub. Ouvrir avec **Unity 6000.3.27f1** et charger `Assets/Scenes/Interaction.unity`.

Le projet utilise XRI 3.3.0, OpenXR 1.16.0 et Input System 1.17.0. Les Starter Assets fournis restent dans le dossier `3.1.2`, qui correspond à la version du sample lors de son import. Ne pas les réimporter avec une autre version. L’archive d’origine a été enregistrée avec Unity 6000.3.1f1 et reste conservée dans le premier commit.

## Lancer sur un Meta Quest 2

1. Installer Android Build Support, Android SDK/NDK et OpenJDK pour cet éditeur.
2. Brancher le Quest 2 en mode développeur et autoriser le débogage USB.
3. Dans `File > Build Profiles`, activer Android et vérifier que `Interaction` est la scène incluse.
4. Conserver OpenXR comme fournisseur Android, le profil Oculus Touch, IL2CPP, ARM64, Vulkan et Multi Pass.
5. Lancer `Build And Run`. Quitter Quest Link si son interface prend la place de l’application autonome.

L’identifiant Android est `com.pacome.interaction3d`. La version finale testée au Quest 2 est la version 0.1.4, code 5. Multi Pass reprend le réglage qui avait corrigé le dédoublement des contrôleurs dans le TP précédent.

## Commandes

| Commande | Action |
| --- | --- |
| Joystick gauche | Déplacement continu |
| X | Changer de mode de navigation, dont la téléportation |
| B | Technique de la main droite |
| Y | Technique de la main gauche |
| Gâchette sous l’index | Créer un bloc sur un générateur, saisir un bloc ou sélectionner Reset |
| Relâcher la gâchette | Lâcher le bloc |
| Joystick de la main qui tient le bloc | Régler la distance et la rotation lorsque le mode le permet |

Au démarrage, chaque main est en saisie directe. B et Y parcourent indépendamment cet ordre :

| Appuis depuis le démarrage | Mode | Comportement |
| --- | --- | --- |
| 0 | Direct Interactor | Saisie au contact |
| 1 | Ray Fixed, bleu | Saisie à distance fixe |
| 2 | Ray Adjustable, vert | Distance et rotation réglables au joystick |
| 3 | Ray Force Grab, orange | Rappel à la main, attache réglable |
| 4 | Near Far, violet | Saisie proche ou lointaine, Far Attach Mode = Far |
| 5 | Near Far Force Grab, jaune | Saisie proche ou rappel à la main, Far Attach Mode = Near |

Le prochain appui revient à la saisie directe. Relâcher le bloc avant de changer de technique. En Near Far jaune, une fois le bloc ramené à la main, son placement se fait avec les mouvements physiques du contrôleur.

Lors d’une manipulation au joystick, les commandes de locomotion qui utilisent le même stick sont suspendues. Elles reprennent après le dernier relâchement concerné. Les deux mains peuvent tenir deux blocs distincts simultanément. Un bloc reste tenu par une seule main à la fois.

## Générateurs et chronomètre

Les deux générateurs d’origine produisent des blocs saisis au centre. Les copies bleu clair et jaune orangé produisent des blocs avec Dynamic Attach, Match Position, Match Rotation et Snap To Collider Volume activés.

Le chronomètre démarre à la première génération après Reset. Un essai dure deux minutes. Chaque étage complet comporte deux blocs de même couleur, perpendiculaires à l’étage précédent, avec une alternance bleu et jaune. Reset supprime les blocs créés et remet le chronomètre à deux minutes.

Un défaut du script fourni a été corrigé : un clic sur un générateur après expiration est consommé, au lieu de rester en attente et de relancer le chronomètre après Reset.

## Rendu

[Rapport PDF](Rapport/Compte_rendu_Interaction3D_Pacome_CAILLETEAU.pdf) · [Version texte](Rapport/compte-rendu.md) · [Tableau comparatif](Rapport/comparaison.csv) · [Détail des essais](Rapport/essais.csv)

## État final et résultats

Les techniques de manipulation ont été testées au Meta Quest 2 avec les contrôleurs Touch : saisie directe, point de contact dynamique, trois variantes du rayon et deux variantes Near Far. Les commandes permettent de changer de technique sur chaque main, de créer les deux couleurs, de saisir et relâcher les blocs, de manipuler avec les deux mains et de réinitialiser la tâche.

Le fichier `Rapport/essais.csv` contient les 16 essais de deux minutes, soit deux par configuration. `Rapport/comparaison.csv` en donne la synthèse avec les deux scores et le meilleur résultat. Le rapport présente les réglages et les observations pour chaque technique.

Les notes par étape reprennent les sections du rapport. Les captures légendées sont dans `Rapport/captures`. La version à ouvrir pour tester l’application finale est `main`. Les commits par étape permettent de suivre la progression.

[Consignes du compte rendu](https://www.etiennepeillard.com/fr/teaching/tutorial/rapport-tp/) · [Cours Interaction 3D](https://www.etiennepeillard.com/fr/slides/vr-interaction/)
