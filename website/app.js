import express from "express";
import cors from "cors";
const app = express();
const port = 3001;

app.set("view engine", "ejs");

app.use(express.json());

app.use(express.static('public'));

app.use(cors());


app.get("/", (req, res) => {
  res.render("index");
});

app.listen(port, () => {
  console.log(`Servidor escuchando en http://localhost:${port}`);
});
