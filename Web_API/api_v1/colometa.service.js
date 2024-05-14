import * as colometaMysql from './colometa.mysql.js'

const getCarreras = async () => {
  try {
    const carreras = await colometaMysql.getCarreras();
    return carreras;
  } catch (err) {
    console.error(err);
  }
};

const getAlumno = async (matricula) => {
  try {
    const alumno = await colometaMysql.getAlumno(matricula);
    return alumno;
  } catch (err) {
    console.error(err);
  }
};

export {
  getCarreras,
  getAlumno,
};