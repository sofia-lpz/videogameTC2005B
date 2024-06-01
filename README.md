# Como correr Chasing Colometa:

1. Crear un usuario de mysql colometa, contraseña colometa, con permisos de root
2. Entrar a la carpeta de Data_Base, correr schema.sql, datos_finales.sql

3. Entrar a la carpeta Web_API
4. iniciar un proyecto de node e instalar las dependencias
en una terminal dentro de Web_API, mandar el comando "npm run dev"
Confirmacion dice: "Pronostico escuchando en puerto 3000"

5. Entrar a el proeycto de unity llamado Lost Illusion
6. Entrar a la escena mainMenu. Assets/Scenes/mainMenu
7. play a la escena

Los botones estan desactivados y se activan cuando se hace una request correcta a la api
Start tiene una funcion que ignora la autentificacion y directamente deja comenzar el juego para facilitar el desarrollo
sin embargo login da un mensaje de error o exito de autentificacion
user: player
contraseña: admin

El resto del juego tiene instrucciones.


# Para el TCG:

Se puede cambiar de personaje una vez por turno y tiene costo de energia el cambio
Cada turno te dan energia aleatoria
Las cartas tienen costo de energia, pueden ser de ataque, defensa o recuperar hp

Los personajes se hacen daño por sinergia de 5:
Reason vence Terror y Spirit
Terror vence Ennui y Dream
Ennui vence Spirit y Reason
Spirit vence Dream y Terror
Dream vence Reason y Ennui

# Falta:
Agregar más sprites.

Agregar más animaciones.

Agregar más dialogos.

Agregar eventos

más soundtracks

(basicamente extender el mundo, con mecanicas ya probadas como scene change, cutscenes, triggers, audio managers etc)

Registro

Mas feedback en las matches

Posts a la api de stats relevantes

Modular dificultad de IA
