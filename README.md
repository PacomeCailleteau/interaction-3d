# Interaction 3D

Pacôme CAILLETEAU, FIL A3 Front.

TP RX sur les techniques de manipulation en réalité virtuelle. Le projet de départ est celui fourni par Cédric Fleury sur la page du TP d’Étienne Peillard.

## Ouvrir le projet

Cloner ce dépôt, puis ajouter le dossier dans Unity Hub. Ouvrir avec Unity 6000.3.27f1 et charger `Assets/Scenes/Interaction.unity`.

L’archive fournie a été créée avec Unity 6000.3.1f1. Sa version d’origine est conservée dans le premier commit. Les packages du sujet sont conservés, dont XRI 3.3.0, OpenXR 1.16.0 et Input System 1.17.0. Les Starter Assets restent ceux du dossier 3.1.2. Les groupes de recommandations VR et Development ont été retirés pour empêcher Unity 6.3.27 de remplacer automatiquement les versions du sujet. Leurs packages nécessaires restent installés individuellement.

## Étape 1

La scène contient les générateurs bleu et jaune, la plateforme centrale, le bouton Reset et le chronomètre de deux minutes. La saisie directe et les points d’attache fournis sont conservés.

La cible est un Meta Quest 2 autonome. Installer Android Build Support, le SDK/NDK et OpenJDK pour cet éditeur. Dans Build Profiles, choisir Android et la scène `Interaction`. La configuration utilise OpenXR, Oculus Touch, Vulkan et Multi Pass. L’identifiant `com.pacome.interaction3d` permet de garder le TP Intro VR installé à côté.

Le mode Multi Pass reprend le réglage qui avait corrigé le dédoublement des contrôleurs dans le TP précédent.

## Commandes à vérifier au casque

- Joystick gauche pour la navigation continue.
- X pour changer de mode de navigation.
- Mettre le contrôleur droit en contact avec un générateur et appuyer sur la gâchette de l’index pour créer un bloc.
- Utiliser la même gâchette au contact d’un bloc pour le saisir, puis la relâcher pour le poser.
- Sélectionner Reset pour vider la scène et remettre le chronomètre à zéro.

Un défaut du script fourni a été corrigé : un clic sur un générateur après la fin du temps est maintenant consommé, au lieu de rester en attente et de relancer automatiquement un essai après Reset.

Le chronomètre démarre à la première génération après Reset. Une fois le temps écoulé, utiliser Reset avant un nouvel essai.

## Mesures pour le rapport

Faire un court entraînement, puis deux essais de deux minutes avec la saisie directe initiale. Réinitialiser entre les essais. Compter les étages complets encore debout, avec deux blocs de même couleur par étage, une orientation perpendiculaire à l’étage précédent et une alternance bleu/jaune.

Renseigner `Rapport/essais.csv` avec les scores et les observations. Conserver le premier score, le meilleur score et le nombre d’essais. Préciser le mode de navigation préféré et pourquoi il convient à cette tâche.

Les comparaisons suivantes garderont la même durée et le même nombre d’essais. Les nouveaux modes seront ajoutés après validation de chaque étape.

## Rendu attendu

Le rendu est un rapport PDF avec l’identité, la formation, le cours, la date et le lien du dépôt. Il présente les étapes avec des captures légendées, les réglages testés, les difficultés rencontrées et un bilan comparatif. Les scores et le ressenti sont présentés séparément.

Le PDF anglais téléchargeable est le sujet original. Les réponses sont à intégrer au rapport, sans questionnaire séparé.

Dépôt : https://github.com/PacomeCailleteau/interaction-3d

Sujet : https://www.etiennepeillard.com/fr/teaching/lab/3d-interaction/
