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
    body: { username, won },
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
    body: { username, mostUsedCard, mostUsedVillager, leastUsedCard, leastUsedVillager, memoriesFound },
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

const createCardUse = async (req, res) => {
  const { body: { username, cards } } = req;

  if (!username || !cards || !Array.isArray(cards)) {
    res.status(400).send({ status: "Error", data: "Username and cards are required." });
    return;
  }

  try {
    const results = [];
    for (const card of cards) {
      const { cardId, timesUsed } = card;
      if (!cardId || timesUsed === undefined) {
        res.status(400).send({ status: "Error", data: "Each card must have a cardId and timesUsed." });
        return;
      }

      const result = await colometaService.createCardUse(username, cardId, timesUsed);
      if (result.error) {
        res.status(500).send({ status: "Error", data: result.error });
        return;
      }

      results.push(result);
    }

    res.send({ status: "OK", data: results });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const createVillagerUse = async (req, res) => {
  const { body: { username, villagers } } = req;

  if (!username || !villagers || !Array.isArray(villagers)) {
    res.status(400).send({ status: "Error", data: "Username and villagers are required." });
    return;
  }

  try {
    const results = [];
    for (const villager of villagers) {
      const { villagerId, timesUsed } = villager;
      if (!villagerId || timesUsed === undefined) {
        res.status(400).send({ status: "Error", data: "Each villager must have a villagerId and timesUsed." });
        return;
      }

      const result = await colometaService.createVillagerUse(username, villagerId, timesUsed);
      if (result.error) {
        res.status(500).send({ status: "Error", data: result.error });
        return;
      }

      results.push(result);
    }

    res.send({ status: "OK", data: results });
  }
  catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getMatchResults = async (req, res) => {
  try {
    const matchResults = await colometaService.getMatchResults();
    res.send({ status: "OK", data: matchResults });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getCardUse = async (req, res) => {
  try {
    const cardUse = await colometaService.getCardUse();
    res.send({ status: "OK", data: cardUse });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

const getVillagerUse = async (req, res) => {
  try {
    const villagerUse = await colometaService.getVillagerUse();
    res.send({ status: "OK", data: villagerUse });
  } catch (error) {
    console.error(error);
    res.status(500).send({ status: "Error", data: error.message });
  }
}

export {
  getVillagerUse,
  getCardUse,
  getMatchResults,
  createVillagerUse,
  createCardUse,
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