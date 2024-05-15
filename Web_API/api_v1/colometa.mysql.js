import mysql from "mysql2/promise"

// NEEDS QUERIES

async function connectToDB()
{
  return await  mysql.createConnection({
    host: 'localhost',
    user: 'hagen',
    database: 'colometa',
    password: 'colometa.',
  });
}

async function getCards()
{
  let connection = null;
  let query = `SELECT * from carta`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query)

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

async function getPlayer(username)
{
  let connection = null;
  let query = `SELECT * from jugador WHERE nombre = ?`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query, [username])

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

async function getDialogues()
{
  let connection = null;
  let query = `SELECT * from dialogo`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query)

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

async function getStats()
{
  let connection = null;
  let query = `SELECT * from estadistica`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query)

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

async function getMatches()
{
  let connection = null;
  let query = `SELECT * from partido`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query)

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

async function getVillagers()
{
  let connection = null;
  let query = `SELECT * from aldeano`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query)

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

async function getPlayerTeam(username)
{
  let connection = null;
  let query = `SELECT * from equipo WHERE nombre = ?`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query, [username])

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

async function getPlayerDeck(username)
{
  let connection = null;
  let query = `SELECT * from mazo WHERE nombre = ?`
  try
  {
    connection = await connectToDB()

    const [results, _] = await connection.query(query, [username])

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
  getCards,
  getPlayer,
  getDialogues,
  getStats,
  getMatches,
  getVillagers,
  getPlayerTeam,
  getPlayerDeck
};
