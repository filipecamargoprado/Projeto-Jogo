import { useEffect, useState } from "react";

function ConsultarCEP() {
  const [localidade, setlocalidade] = useState("");
  const [estado, setestado] = useState("");
  const [logradouro, setlogradouro] = useState("");
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
        console.log(endereco); // Adicione esta linha para verificar a resposta
        if (endereco.localidade) {
          digitarGradualmente(endereco.localidade, setlocalidade);
        }
        if (endereco.logradouro) {
          digitarGradualmente(endereco.logradouro, setlogradouro);
        }
        if (endereco.uf) {
          digitarGradualmente(endereco.uf, setestado)
        }
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