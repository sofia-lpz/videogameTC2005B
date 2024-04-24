import express from 'express'
import * as pronosController from './pronos.controller.js'

const router = express.Router();

router.get("/carreras", pronosController.getCarreras);
//regresa nombre de carrera itc, itd, etc

router.get("/matricula/:matricula", pronosController.getAlumno);
//regresa json con datos del alumno

//router.get("/:carrera/:semestre", pronosController.getCarrerasSemestre);

//CONVENTIONS FOR ROUTES
//carreras son ITC, ITD, etc
//programas son itc19, itc26, etc



//References:
//router.get("/", tareasController.getAll);
//router.get("/:tareaID", tareasController.getOne);
//router.post("/", tareasController.create);
//router.patch("/:tareaID", tareasController.update);
//router.delete("/:tareaID", tareasController.deleteOne);

export { router }