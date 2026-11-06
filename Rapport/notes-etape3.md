# 3. Saisir au point de contact


J’ai dupliqué les deux générateurs et les deux prefabs pour garder la saisie d’origine disponible. Les copies sont bleu clair et jaune orangé. Chaque nouveau générateur référence son prefab et le même chronomètre.

Sur les copies, Use Dynamic Attach calcule l’attache lors de la prise. Match Position utilise le point de contact, Match Rotation conserve l’orientation au moment de la prise et Snap To Collider Volume limite l’attache au volume du bloc. Les options sont activées dans la configuration retenue.

![Bloc d’origine : le centre est ramené dans la main.](captures/etape-3-saisie-centre.png)

![Bloc dynamique : la prise reste près de l’extrémité.](captures/etape-3-saisie-contact.png)

Je préfère la saisie au point de contact, car le bloc reste tenu à l’endroit où je l’attrape. En le prenant par une extrémité, je peux le positionner sans devoir autant avancer les bras.

Cette différence est surtout utile pour replacer un bloc sous ceux qui sont déjà empilés. Avec la saisie d’origine, le bloc se recentre brusquement dans la main. Ce déplacement peut heurter les blocs voisins et faire tomber une partie de la tour. La saisie au point de contact permet de le reprendre sans ce décalage.

Le choix de la prise reste important. Tourner le contrôleur fait pivoter le bloc autour du point choisi. Une prise à l’extrémité donne de la portée, mais l’autre bout du bloc décrit un mouvement plus large. Il faut en tenir compte près des blocs déjà posés.

Dans le casque, j’ai pu créer des blocs avec les quatre générateurs, les saisir et les relâcher. Les deux nouveaux blocs restent tenus au point où je les prends. Reset supprime bien les blocs créés.
