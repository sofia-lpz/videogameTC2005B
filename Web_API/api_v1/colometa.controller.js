import * as colometaService from './colometa.service.js'

const getCarreras = async (req, res) => {
  try {
    const carreras = await colometaService.getCarreras();
    res.send({ status: "OK", data: carreras });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message});
  }
};

const getAlumno = async (req, res) => {

  const {
    params: { matricula },
  } = req;
  if (!matricula) {
    return;
  }

  try {
    const alumno = await colometaService.getAlumno(matricula);
    res.send({ status: "OK", data: alumno });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
};

const getCarreraSemestre = async (req, res) => {
  const {
    params: { carrera, semestre },
  } = req;
  if (!carrera || !semestre) {
    return;
  }

  try {
    const colometatico = await colometaService.getCarreraSemestre(carrera, semestre);
    res.send({ status: "OK", data: colometatico });
  }
catch(error){
  console.error(error);
  res.status(500).send({ status: "Error", data: error.message });
}
};

export {
  getCarreras,
  getAlumno,
  getCarreraSemestre,
};