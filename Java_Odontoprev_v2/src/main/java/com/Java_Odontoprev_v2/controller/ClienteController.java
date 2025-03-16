package com.Java_Odontoprev_v2.controller;

import com.Java_Odontoprev_v2.model.Cliente;
import com.Java_Odontoprev_v2.repository.ClienteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@Controller
@RequestMapping("/cliente")
@RequiredArgsConstructor
@Validated
public class ClienteController {

    @Autowired
    private ClienteRepository clienteRepository;

    @GetMapping("/lista")
    public String listaCliente(Model model) {
        List<Cliente> clientes = clienteRepository.findAll();
        model.addAttribute("clientes", clientes);
        return "cliente/lista";
    }

    @GetMapping("/novo")
    public String novoCliente(Model model) {
        model.addAttribute("cliente", new Cliente());
        return "cliente/novo";
    }

    @PostMapping("/salvar")
    public String salvarCliente(@ModelAttribute Cliente cliente, BindingResult result, Model model) {
        if (result.hasErrors()) {
            model.addAttribute("cliente", cliente);
            return "cliente/formulario";
        }
        clienteRepository.save(cliente);
        return "redirect:/cliente/lista";
    }

    @GetMapping("/editar/{cpfCnpj}")
    public String editarCliente(@PathVariable String cpfCnpj, Model model) {
        Optional<Cliente> cliente = clienteRepository.findById(cpfCnpj);
        if (cliente.isPresent()) {
            model.addAttribute("cliente", cliente.get());
            return "cliente/formulario";
        }
        return "cliente/novo";
    }

    @GetMapping("/deletar/{cpfCnpj}")
    public String deletarCliente(@PathVariable String cpfCnpj) {
        clienteRepository.deleteById(cpfCnpj);
        return "redirect:/cliente/lista";
    }

}
