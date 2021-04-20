import axios from "axios";
import baseUrl from "./config";

const loavesUrl = `${baseUrl}/loaves`;

const GetAllLoaves = () => new Promise((resolve, reject) => {
    axios
      .get(loavesUrl)
      .then((response) => {
        resolve(response.data);
      })
      .catch((error) => reject(error));
  });

export default{
    GetAllLoaves
}
