import { router } from './colometa.routes.js';
import * as colometaService from './colometa.service.js'

const getCards = async (req, res) => {
  try {
    const cards = await colometaService.getCards();
    res.send({ status: "OK", data: cards });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getPlayer = async (req, res) => {
  const {
    params: { username },
  } = req;
  if (!username) {
    return;
  }

  try {
    const player = await colometaService.getPlayer(username);
    res.send({ status: "OK", data: player });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getDialogues = async (req, res) => {
  try {
    const dialogues = await colometaService.getDialogues();
    res.send({ status: "OK", data: dialogues });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getStats = async (req, res) => {
  try {
    const stats = await colometaService.getStats();
    res.send({ status: "OK", data: stats });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getMatches = async (req, res) => {
  try {
    const matches = await colometaService.getMatches();
    res.send({ status: "OK", data: matches });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getVillagers = async (req, res) => {
  try {
    const villagers = await colometaService.getVillagers();
    res.send({ status: "OK", data: villagers });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getPlayerTeam = async (req, res) => {
  const {
    params: { username },
  } = req;
  if (!username) {
    return;
  }

  try {
    const team = await colometaService.getPlayerTeam(username);
    res.send({ status: "OK", data: team });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getPlayerDeck = async (req, res) => {
  const {
    params: { username },
  } = req;
  if (!username) {
    return;
  }

  try {
    const deck = await colometaService.getPlayerDeck(username);
    res.send({ status: "OK", data: deck });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getPlayerMatches = async (req, res) => {
  const {
    params: { username },
  } = req;
  if (!username) {
    return;
  }

  try {
    const matches = await colometaService.getPlayerMatches(username);
    res.send({ status: "OK", data: matches });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getPlayerStats = async (req, res) => {
  const {
    params: { username },
  } = req;
  if (!username) {
    return;
  }

  try {
    const stats = await colometaService.getPlayerStats(username);
    res.send({ status: "OK", data: stats });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getAuth = async (req, res) => {
  const {
    params: { username, password },
  } = req;
  if (!username || !password) {
    return;
  }

  try {
    const auth = await colometaService.getAuth(username, password);

    if (auth.length === 0) {
      res.status(404).send({ status: "Error", data: "User or password incorrect" });
      return;
    }

    res.send({ status: "OK", data: auth });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const createPlayer = async (req, res) => {
  const {
    params: { username, password },
  } = req;
  if (!username || !password) {
    return;
  }

  try {
    const result = await colometaService.createPlayer(username, password);
    
    // Check if an error was returned
    if (result.error) {
      res.status(500).send({ status: "Error", data: result.error });
      return;
    }

    res.send({ status: "OK", data: result });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const createPlayerMatch = async (req, res) => {
  const {
    params: { username, won },
  } = req;

  if (!username || won === undefined) {
    res.status(400).send({ status: "Error", data: "Username and match result are required." });
    return;
  }

  try {
    const result = await colometaService.createPlayerMatch(username, won === 'true');
    
    if (result.error) {
      res.status(500).send({ status: "Error", data: result.error });
      return;
    }

    res.send({ status: "OK", data: result });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const createPlayerStats = async (req, res) => {
  const {
    params: { username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound },
  } = req;

  if (!username || !mostUsedCard || !mostUsedVillager || !leastUsedCard || !leastUsedVillager || memoriesFound === undefined) {
    res.status(400).send({ status: "Error", data: "All fields are required." });
    return;
  }

  try {
    const result = await colometaService.createPlayerStats(username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound);
    
    if (result.error) {
      res.status(500).send({ status: "Error", data: result.error });
      return;
    }

    res.send({ status: "OK", data: result });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

export {
  createPlayerStats,
  createPlayerMatch,
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