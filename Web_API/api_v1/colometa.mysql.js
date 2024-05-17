import mysql from "mysql2/promise";

// Function to connect to the database
async function connectToDB() {
  return await mysql.createConnection({
    host: 'localhost',
    user: 'hagen',
    database: 'colometa',
    password: 'colometa.',
  });
}

// Function to get all cards
async function getCards() {
  let connection = null;
  let query = `SELECT * FROM card`;  // Corrected table name
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get player by username
async function getPlayer(username) {
  let connection = null;
  let query = `SELECT * FROM player WHERE username = ?`;  // Corrected table and column names
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username]);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get all dialogues
async function getDialogues() {
  let connection = null;
  let query = `SELECT * FROM dialogue`;  // Corrected table name
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get all stats
async function getStats() {
  let connection = null;
  let query = `SELECT * FROM stats`;  // Corrected table name
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get all matches
async function getMatches() {
  let connection = null;
  let query = `SELECT * FROM tcg_match`;  // Corrected table name
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get all villagers
async function getVillagers() {
  let connection = null;
  let query = `SELECT * FROM villager`;  // Corrected table name
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get a player's team
async function getPlayerTeam(username) {
  let connection = null;
  let query = `SELECT * FROM team WHERE username = ?`;  // Corrected table and column names
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username]);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

// Function to get a player's deck
async function getPlayerDeck(username) {
  let connection = null;
  let query = `SELECT * FROM deck WHERE username = ?`;  // Corrected table and column names
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username]);
    console.log(`${results.length} rows returned`);
    return results;
  } catch (error) {
    console.log(error);
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
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
