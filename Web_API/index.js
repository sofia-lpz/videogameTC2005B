import express from 'express'
import bodyParser from 'body-parser';
import cors from "cors";
import {router} from './api_v1/colometa.routes.js'

const app = express();
const PORT = process.env.PORT || 3000;


app.use(bodyParser.json());
app.use(cors());
app.use("/api", router);


app.listen(PORT, () => {
  console.log(`Colometa api escuchando en el puerto ${PORT}`);
});


