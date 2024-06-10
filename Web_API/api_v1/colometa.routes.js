import express from 'express'
import * as colometaController from './colometa.controller.js'

const router = express.Router();

//get all, necesary and working
router.get("/cards", colometaController.getCards);
router.get("/villagers", colometaController.getVillagers);
router.get("/auth/:username/:password", colometaController.getAuth);

router.post("/register/:username/:password", colometaController.createPlayer);


//extra endpoints
router.get("/player/:username/team", colometaController.getPlayerTeam);
router.get("/player/:username/matches", colometaController.getPlayerMatches);


//Posters
router.post("/create/match", colometaController.createPlayerMatch);
router.post("/create/stats", colometaController.createPlayerStats);

//for stats
router.get("/player/:username", colometaController.getPlayer);
router.get("/player/:username/stats", colometaController.getPlayerStats);


router.get("/stats", colometaController.getStats);
router.get("/matches", colometaController.getMatches);

export { router }