import express from 'express'
import bodyParser from 'body-parser';
<<<<<<< HEAD:Web_API/api_v1/index.js
import cors from "cors";
import {router} from './colometa.routes.js'
=======
import {router} from './api_v1/colometa.routes.js'
>>>>>>> 45e4ff2882306b6205751b663986c1ae74b61775:Web_API/index.js

const app = express();
const PORT = process.env.PORT || 3000;


app.use(bodyParser.json());
app.use(cors());
app.use("/api", router);


app.listen(PORT, () => {
  console.log(`pronostico escuchando en el puerto ${PORT}`);
});


