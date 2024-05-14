import express from 'express'
import * as colometaController from './colometa.controller.js'

const router = express.Router();

router.get("/cards", colometaController.getCarreras);

router.get("/card/:id", colometaController.getCarreras);

router.get("/player/:id", colometaController.getAlumnos);

router.get("/villager/:id", colometaController.getAlumnos);

router.get("/player/:id/matches", colometaController.getAlumnos);

router.get("player/:id/stats", colometaController.getAlumnos);

router.get("/dialogues", colometaController.getAlumnos);

router.get("/dialogue/:id", colometaController.getAlumnos);

//References:
//router.get("/", tareasController.getAll);
//router.get("/:tareaID", tareasController.getOne);
//router.post("/", tareasController.create);
//router.patch("/:tareaID", tareasController.update);
//router.delete("/:tareaID", tareasController.deleteOne);

export { router }