import express from 'express'
import * as colometaController from './colometa.controller.js'

const router = express.Router();

//get all, necesary and working
router.get("/cards", colometaController.getCards);
router.get("/villagers", colometaController.getVillagers);
router.get("/auth/:username/:password", colometaController.getAuth);
router.post("/register/:username/:password", colometaController.createPlayer);

//get all, necesary and working
//Posters
router.post("/create/match", colometaController.createPlayerMatch);
router.post("/create/stats", colometaController.createPlayerStats);

// router.post("/update/carduse", colometaController.createCardUse);
// router.post("/update/villageruse", colometaController.createVillagerUse);
// router.post("/update/memoriesfound", colometaController.createMemoriesFound);

//for stats
router.get("/stats", colometaController.getStats);
router.get("/matches", colometaController.getMatches);

// router.get("/timesplayer/cards", colometaController.getCardstats);
// router.get("/timesplayer/villagers", colometaController.getVillagerstats);

export { router }

// //extra endpoints
// router.get("/player/:username/team", colometaController.getPlayerTeam);
// router.get("/player/:username/matches", colometaController.getPlayerMatches);
// router.get("/player/:username/stats", colometaController.getPlayerStats);
