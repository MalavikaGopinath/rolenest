import axios from "axios";
import type { User, UserCreateDto } from "../types/User";

const API_URL = import.meta.env.VITE_API_URL;

export const getUsers = async (): Promise<User[]> => {
  const response = await axios.get<User[]>(API_URL);
  return response.data;
};

export const getUserById = async (id: string): Promise<User> => {
  const response = await axios.get<User>(`${API_URL}/${id}`);
  return response.data;
};

export const createUser = async (user: UserCreateDto): Promise<User> => {
  const response = await axios.post<User>(API_URL, user);
  return response.data;
};

export const updateUser = async (id: string, user: UserCreateDto): Promise<User> => {
  const response = await axios.put<User>(`${API_URL}/${id}`, user);
  return response.data;
};

export const deleteUser = async (id: string): Promise<void> => {
  await axios.delete(`${API_URL}/${id}`);
};
