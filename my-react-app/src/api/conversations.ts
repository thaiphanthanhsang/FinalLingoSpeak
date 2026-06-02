import apiClient from "./client";
import endpoints from "./endpoints";
import type { Conversation, Translation } from "../types/api";

export const getAllConversations = () =>
  apiClient.get<Conversation[]>(endpoints.conversations.getAll).then((r) => r.data);

export const getConversationById = (id: number) =>
  apiClient.get<Conversation>(endpoints.conversations.getById(id)).then((r) => r.data);

export interface MessagePayload {
  senderName: string;
  translation: Translation;
  order: number;
}

export interface ConversationPayload {
  topic: string;
  speaker1Name?: string;
  speaker2Name?: string;
  messages?: MessagePayload[];
}

export const createConversation = (payload: ConversationPayload) =>
  apiClient.post<Conversation>(endpoints.conversations.create, payload).then((r) => r.data);

export const updateConversation = (id: number, payload: ConversationPayload) =>
  apiClient
    .put<{ message: string }>(endpoints.conversations.update(id), payload)
    .then((r) => r.data);

export const deleteConversation = (id: number) =>
  apiClient
    .delete<{ message: string }>(endpoints.conversations.delete(id))
    .then((r) => r.data);
