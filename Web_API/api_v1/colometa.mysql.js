import mysql from "mysql2/promise";

async function connectToDB() {
  return await mysql.createConnection({
    host: 'localhost',
    user: 'colometa',
    database: 'colometa',
    password: 'colometa',
  });
}

async function getCards() {
  let connection = null;
  let query = `SELECT * FROM card`;
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

async function getPlayer(username, password) {
  let connection = null;
  let query = `SELECT * FROM player WHERE username = ?`;
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

async function getDialogues() {
  let connection = null;
  let query = `SELECT * FROM dialogue`;
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

async function getStats() {
  let connection = null;
  let query = `SELECT * FROM stats`;
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

async function getMatches() {
  let connection = null;
  let query = `SELECT * FROM tcg_match`;
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

async function getVillagers() {
  let connection = null;
  let query = `SELECT * FROM villager`;
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

async function getPlayerTeam(username) {
  let connection = null;
  let query = `SELECT * FROM team WHERE username = ?`;
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

async function getPlayerDeck(username) {
  let connection = null;
  let query = `SELECT * FROM deck WHERE username = ?`;
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

async function getPlayerMatches(username) {
  let connection = null;
  let query = `SELECT * FROM tcg_match WHERE username = ?`;
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

async function getPlayerStats(username) {
  let connection = null;
  let query = `SELECT * FROM stats WHERE username = ?`;
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

async function getAuth(username, password) {
  let connection = null;
  let query = `SELECT * FROM player WHERE username = ? AND password = ?`;
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username, password]);
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

async function createPlayer(username, password) {
  let connection = null;
  let query = `INSERT INTO player (username, password) VALUES (?, ?)`;
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username, password]);
    console.log(`${results.affectedRows} rows affected`);
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
  getPlayerDeck,
  getPlayerMatches,
  getPlayerStats,
  getAuth,
  createPlayer
};