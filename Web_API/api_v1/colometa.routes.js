import express from 'express'
import * as colometaController from './colometa.controller.js'

const router = express.Router();

//get all, necesary and working
router.get("/cards", colometaController.getCards);
router.get("/player/:username", colometaController.getPlayer);

router.get("/stats", colometaController.getStats);
router.get("/matches", colometaController.getMatches);
router.get("/villagers", colometaController.getVillagers);

router.get("/player/:username/team", colometaController.getPlayerTeam);
router.get("/player/:username/deck", colometaController.getPlayerDeck);


<<<<<<< HEAD
// // get specific, might be useful for unity optimising?
// router.get("/card/:id", colometaController.getCard);
// router.get("/villager/:id", colometaController.getVillager);
// router.get("/dialogue/:id", colometaController.getDialogue);

// //get specific by player, might be useful for website?
// router.get("/player/:username/matches", colometaController.getPlayerMatches);
// router.get("player/:username/stats", colometaController.getPlayerStats)

//posters

// router.post("/matches", colometaController.createCarrera);
// router.post("/stats/player/:username", colometaController.createCarrera);

//References:
//router.get("/", tareasController.getAll);
//router.get("/:tareaID", tareasController.getOne);
//router.post("/", tareasController.create);
//router.patch("/:tareaID", tareasController.update);
//router.delete("/:tareaID", tareasController.deleteOne);
=======
// get specific, might be useful for unity optimising?
//router.get("/card/:id", colometaController.getCard);
//router.get("/villager/:id", colometaController.getVillager);


//get specific by player, might be useful for website?
//router.get("/player/:username/matches", colometaController.getPlayerMatches);
//router.get("player/:username/stats", colometaController.getPlayerStats)

//posters

//router.post("/matches", colometaController.createCarrera);
//router.post("/stats/player/:username", colometaController.createCarrera);
>>>>>>> 45e4ff2882306b6205751b663986c1ae74b61775

export { router }