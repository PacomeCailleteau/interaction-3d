# Essais de la saisie directe initiale

Matériel : Meta Quest 2 avec contrôleurs Touch.
Personne réalisant les essais : Pacôme CAILLETEAU.
Durée : deux minutes par essai.
Nombre d’essais prévu après entraînement : trois.

À renseigner après les essais au casque :

- Premier score et meilleur score.
- Nombre d’essais réalisés.
- Mode de navigation retenu et raisons du choix.
- Difficultés pour attraper, tourner et poser les blocs.
- Capture du résultat de la tour et du chronomètre.

## Préparation du projet

Les versions XRI 3.3.0, OpenXR 1.16.0 et Input System 1.17.0 sont conservées. Le fournisseur Android est OpenXR. Les générateurs, les points de saisie et les commandes du sujet sont inchangés.

Un défaut de Reset a été reproduit dans Unity : après expiration, un clic sur un générateur restait en attente et pouvait relancer le chronomètre après Reset. Le clic est maintenant consommé même si la création est refusée. Le même test passe après correction.

Les vérifications dans Unity confirment les deux couleurs, le démarrage au premier bloc, l’arrêt après deux minutes, la suppression des blocs par Reset et le démarrage d’un nouvel essai.

![Vue de départ dans Unity](captures/etape-1-depart.png)

La scène au début d’un essai montre les deux générateurs, la plateforme centrale, le bouton Reset et le chronomètre à 02:00.

## Prise en main au Quest 2

J’ai pu me déplacer et orienter la caméra. En plaçant le contrôleur droit au contact d’un générateur et en appuyant sur la gâchette de l’index, je fais apparaître un bloc que je peux ensuite saisir. La manipulation initiale se fait au contact.

Les scores des trois essais de référence et le choix de navigation restent à relever.
