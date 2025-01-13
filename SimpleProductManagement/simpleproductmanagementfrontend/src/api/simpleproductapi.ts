import axios from "axios";
import { ProductModel } from "../models/productmodel";

const baseUrl = "https://localhost:7083/api";

export const getProducts = async (): Promise<ProductModel[]> => {
  try {
    const response = await axios.get(`${baseUrl}/product`);
    return response.data;
  } catch (error) {
    console.error(error);
    return [];
  }
};
