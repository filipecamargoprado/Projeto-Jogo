import { useEffect, useState } from "react";

function ConsultarCEP() {
  const [localidade, setLocalidade] = useState("");
  const [estado, setEstado] = useState("");
  const [logradouro, setLogradouro] = useState("");
  const [cep, setCep] = useState("");

  useEffect(() => {
    //Evento de carregamento do componente
    //Executar código ao abrir carregar o componente
    //AXIOS - Biblioteca de requisições
    // consultarCEP();
  });

  function digitarGradualmente(texto: string, setter: React.Dispatch<React.SetStateAction<string>>) {
    let index = 0;
    setter("")
    const interval = setInterval(() => {
      if (index < texto.length) {
        setter((prev) => prev + texto[index]);
        index++;
      } else {
        clearInterval(interval);
      }
    }, 90);
  }

  function pesquisarCEP() {
    fetch("https://viacep.com.br/ws/" + cep + "/json/")
      .then((resposta) => resposta.json())
      .then((endereco) => {
        digitarGradualmente(endereco.localidade, setLocalidade);
        digitarGradualmente(endereco.logradouro, setLogradouro);
        digitarGradualmente(endereco.uf, setEstado);
      });
  }

  function sairFoco() {
    pesquisarCEP();
  }

  function digitar(event: any) {
    setCep(event.target.value);
  }

  function clicar() {
    pesquisarCEP();
  }

  return (
    <div id="consultar_cep">
      <h1>Consultar CEP</h1>

      <input
        type="text"
        placeholder="Digite o seu CEP"
        onChange={digitar}
        onBlur={sairFoco}
      />

      <button onClick={clicar}>Consultar CEP</button>

      <p> {localidade} </p>
      <p> {estado} </p>
      <p> {logradouro} </p>
      <p> {cep} </p>
    </div>
  );
}

export default ConsultarCEP;