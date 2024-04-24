import * as pronosMysql from './pronos.mysql.js'

const getCarreras = async () => {
  try {
    const carreras = await pronosMysql.getCarreras();
    return carreras;
  } catch (err) {
    console.error(err);
  }
};

const getAlumno = async (matricula) => {
  try {
    const alumno = await pronosMysql.getAlumno(matricula);
    return alumno;
  } catch (err) {
    console.error(err);
  }
};

export {
  getCarreras,
  getAlumno,
};