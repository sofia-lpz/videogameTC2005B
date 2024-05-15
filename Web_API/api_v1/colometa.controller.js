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

export {
  getCards,
  getPlayer,
  getDialogues,
  getStats,
  getMatches,
  getVillagers,
  getPlayerTeam,
  getPlayerDeck,
};