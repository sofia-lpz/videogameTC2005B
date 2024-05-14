import mysql from "mysql2/promise"

async function connectToDB()
{
  return await  mysql.createConnection({
    host: 'localhost',
    user: 'hagen',
    database: 'colometa',
    password: 'colometa.',
  });
}

async function getCarreras()
{
  let connection = null;
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query('SELECT carrera from programa')

    console.log(`${results.length} rows returned`)
    return results
  }
  catch(error)
  {
    console.log(error)
  }
  finally
  {
    if(connection !== null)
    {
      connection.end()
      console.log('Connection closed successfuly')
    }
  }
}

async function getAlumno(matricula)
{
  let connection = null
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query('SELECT * from alumno WHERE matricula = ?', [matricula])

    console.log(`${results.length} rows returned`)
    return results
  }
  catch(error)
  {
    console.log(error)
  }
  finally
  {
    if(connection !== null)
    {
      connection.end()
      console.log('Connection closed successfuly')
    }
  }
}

export {
  getCarreras,
  getAlumno,
};
