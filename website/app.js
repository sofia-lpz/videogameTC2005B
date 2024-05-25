"use strict"

import express from "express";
const app = express();
const port = 3001;

// Configura EJS como motor de plantillas
app.set("view engine", "ejs");

// Middleware para parsear JSON
app.use(express.json());

// Ruta GET para la raíz
app.get("/", (req, res) => {
  res.render("index");
});

// Inicia el servidor
app.listen(port, () => {
  console.log(`Servidor escuchando en http://localhost:${port}`);
});
