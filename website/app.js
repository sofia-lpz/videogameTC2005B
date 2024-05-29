<<<<<<< HEAD
"use strict";

import express from "express";
import path from "path";
import { fileURLToPath } from 'url';
import { dirname } from 'path';

const app = express();
const port = process.env.PORT || 3001;

const __filename = fileURLToPath(import.meta.url);
const __dirname = dirname(__filename);
=======
import express from "express";
import cors from "cors";
const app = express();
const port = 3001;
>>>>>>> b4079ad304fa6f5fb74fb41013968892fcd059fc

app.set("view engine", "ejs");

app.use(express.json());

<<<<<<< HEAD
app.use(express.static(path.join(__dirname, 'public')));
=======
app.use(express.static('public'));

app.use(cors());

>>>>>>> b4079ad304fa6f5fb74fb41013968892fcd059fc

app.get("/", (req, res) => {
  res.render("html");
});

app.listen(port, () => {
  console.log(`Corriendo en http://localhost:${port}`);
});
