﻿
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UrbanFarmMobile.Models;

namespace UrbanFarmMobile.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://10.0.2.2:5078"); // Altere para sua URL base da API
        }

        public async Task<APIResponse<List<Fornecedor>>> GetFornecedoresAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Fornecedores");
                if (response.IsSuccessStatusCode)
                {
                    var fornecedores = await response.Content.ReadFromJsonAsync<List<Fornecedor>>();
                    return new APIResponse<List<Fornecedor>> { Success = true, Data = fornecedores };
                }
                else
                {
                    return new APIResponse<List<Fornecedor>> { Success = false, Message = "Falha ao obter fornecedores." };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<List<Fornecedor>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse<List<Funcionario>>> GetFuncionariosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Funcionarios");
                if (response.IsSuccessStatusCode)
                {
                    var funcionarios = await response.Content.ReadFromJsonAsync<List<Funcionario>>();
                    return new APIResponse<List<Funcionario>> { Success = true, Data = funcionarios };
                }
                else
                {
                    return new APIResponse<List<Funcionario>> { Success = false, Message = "Falha ao obter funcionários." };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<List<Funcionario>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse<List<Produto>>> GetProdutosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Produtos");
                if (response.IsSuccessStatusCode)
                {
                    var produtos = await response.Content.ReadFromJsonAsync<List<Produto>>();
                    return new APIResponse<List<Produto>> { Success = true, Data = produtos };
                }
                else
                {
                    return new APIResponse<List<Produto>> { Success = false, Message = "Falha ao obter produtos." };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<List<Produto>> { Success = false, Message = ex.Message };
            }
        }

        public async Task<APIResponse<Funcionario>> LoginAsync(string email, string senha)
        {
            var loginRequest = new { Email = email, Senha = senha };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Funcionarios/login", loginRequest);
                if (response.IsSuccessStatusCode)
                {
                    var funcionario = await response.Content.ReadFromJsonAsync<Funcionario>();
                    return new APIResponse<Funcionario>
                    {
                        Success = true,
                        Data = funcionario,
                        Message = "Login bem-sucedido"
                    };
                }
                else
                {
                    return new APIResponse<Funcionario>
                    {
                        Success = false,
                        Message = $"E-mail ou senha incorretos. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<Funcionario>
                {
                    Success = false,
                    Message = $"Erro de conexão: {ex.Message}"
                };
            }
        }
    }
}
