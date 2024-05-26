import express from 'express'
import bodyParser from 'body-parser';
import {router} from './api_v1/colometa.routes.js'

const app = express();
const PORT = process.env.PORT || 3000;


app.use(bodyParser.json());
app.use("/api", router);

app.listen(PORT, () => {
  console.log(`pronostico escuchando en el puerto ${PORT}`);
});


