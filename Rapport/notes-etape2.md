# 2. Préparer le changement de technique sur chaque contrôleur

Le composant Controller Manager est déjà présent sur les deux contrôleurs. Le bouton B permet de changer de technique à droite et le bouton Y à gauche. Chaque technique doit être placée directement sous le contrôleur et avoir le tag ControllerMode.

Pour vérifier le fonctionnement, j’ai utilisé des modes temporaires et des entrées simulées dans Unity. Chaque bouton change bien le mode de la main concernée sans modifier l’autre. Un seul mode reste actif par main et le cycle revient au premier après le dernier. Garder le bouton enfoncé ne provoque pas de changements répétés. Les modes temporaires ont ensuite été retirés.

La capture ci-dessous montre la configuration utilisée pendant le test, avec les modes temporaires.

![Configuration du changement de mode dans Unity](captures/etape-2-changement-de-mode.png)
