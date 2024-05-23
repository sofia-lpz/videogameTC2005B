import express from "express";
import cors from "cors"; // Importa el paquete cors
const app = express();
const port = 3001;

// Configura EJS como motor de plantillas
app.set("view engine", "ejs");

// Middleware para parsear JSON
app.use(express.json());

//Middleware para carpeta public
app.use(express.static('public'));

// Middleware para permitir CORS
app.use(cors());

// Ruta GET para la raíz
app.get("/", (req, res) => {
  res.render("index");
});

// Inicia el servidor
app.listen(port, () => {
  console.log(`Servidor escuchando en http://localhost:${port}`);
});
