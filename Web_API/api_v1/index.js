import express from 'express'
import bodyParser from 'body-parser';
import {router} from './pronos.routes.js'

const app = express();
const PORT = process.env.PORT || 3000;

app.use(bodyParser.json());
app.use("/api/pronos", router);

app.listen(PORT, () => {
  console.log(`pronostico escuchando en el puerto ${PORT}`);
});

