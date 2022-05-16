import React, {useState } from 'react'
import Api from "../../services/clientes-api"

export default function Cadastrar({recarregar}) {

    const [formulario, setFormulario] = useState({
       Nome: "",
       Porte: 0 
    });

    const onChange = event => {
        const { name, value } = event.target;
        setFormulario({...formulario, [name]: value});
    }

    const onCadastrar = async () => {
        const request = formulario;
        const response = await Api.post("", request);
        if(response.status == 201){
            recarregar();
            document.getElementById("fecharCadastrarModal").click();
        }
    }

  return (
    <div className="modal fade" id="cadastrarModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div className="modal-dialog" role="document">
            <div className="modal-content">
                <div className="modal-header">
                    <h5 className="modal-title">Novo Cliente</h5>
                    <button type="button" className="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <form>
                    <div className="modal-body">
                        <div className="row">
                            <div className="input-field col s4">
                                <label className="input-field" htmlFor="Nome">Nome</label>
                                <input
                                    className="validate"
                                    id="Nome"
                                    type="text"
                                    name="Nome"
                                    value={formulario.Nome}
                                    onChange={onChange}
                                />
                            </div>

                            <div className="input-field col s4">
                                <label className="input-field" htmlFor="Porte">Porte</label>
                                <select className="validate" id="Porte" name="Porte" value={formulario.Porte}  onChange={onChange}>
                                    <option value="Pequeno">Pequeno</option>
                                    <option value="Medio" selected>Medio</option>
                                    <option value="Grande">Grande</option>
                                </select>
                         
                            </div>


                        </div>

                        <button type="button" onClick={onCadastrar} className="btn btn-primary btn-sm">Cadastrar</button>
                        <button type="button" id="fecharCadastrarModal" className="btn btn-secondary btn-sm" data-dismiss="modal">Cancelar</button>
                    </div>
               </form>
            </div>
        </div>
    </div>
  )
}
