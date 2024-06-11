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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
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
    return { error: error.message };
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

async function createPlayerMatch(username, won) {
  let connection = null;
  let query = `INSERT INTO tcg_match (username, won) VALUES (?, ?)`;
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username, won]);
    console.log(`${results.affectedRows} rows affected`);
    return results;
  } catch (error) {
    console.log(error);
    return { error: error.message };
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

async function createPlayerStats(username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound) {
  let connection = null;
  let query = `INSERT INTO stats (username, most_used_card, most_used_villager, least_used_card, least_used_villager, memories_found) VALUES (?, ?, ?, ?, ?, ?)`;
  try {
    connection = await connectToDB();
    const [results, _] = await connection.query(query, [username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound]);
    console.log(`${results.affectedRows} rows affected`);
    return results;
  } catch (error) {
    console.log(error);
    return { error: error.message };
  } finally {
    if (connection !== null) {
      connection.end();
      console.log('Connection closed successfully');
    }
  }
}

export {
  createPlayerStats,
  createPlayerMatch,
  getCards,
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