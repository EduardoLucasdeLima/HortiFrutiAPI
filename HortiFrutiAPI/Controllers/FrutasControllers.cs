using AutoMapper;
using HortiFrutiAPI.DTOs;
using HortiFrutiAPI.Models;
using HortiFrutiAPI.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace HortiFrutiAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class FrutasController : ControllerBase
{
    private readonly IUnitOfWork _uof;
    private readonly IMapper _mapper;

    public FrutasController(IUnitOfWork uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }

    [HttpGet("frutas/{id}")]
    public ActionResult<IEnumerable<FrutaDTO>> GetFrutasCategoria(int id)
    {
      var frutas = _uof.FrutaRepository.GetFrutasPorCategoria(id);
        if (frutas is null)
            return NotFound();

        var frutasDto = _mapper.Map<IEnumerable<FrutaDTO>>(frutas);

        return Ok(frutasDto);
    }

    [HttpGet]
    public ActionResult<IEnumerable<FrutaDTO>> Get()
    {
        var frutas = _uof.FrutaRepository.GetAll();
        if (frutas is null)
        {
            return NotFound();
        }
        var frutasDto = _mapper.Map<IEnumerable<FrutaDTO>>(frutas);
        return Ok(frutasDto);
    }

    [HttpGet("{id}", Name = "ObterFruta")]
    public ActionResult<FrutaDTO> Get(int id)
    {
        var fruta = _uof.FrutaRepository.Get(c => c.FrutaId == id);
        if (fruta is null)
        {
            return NotFound("Fruta não encontrada...");
        }
        var frutasDto = _mapper.Map<FrutaDTO>(fruta);
        return Ok(fruta);
    }

    [HttpPost]
    public ActionResult<FrutaDTO> Post(FrutaDTO frutaDto)
    {
        if (frutaDto is null)
            return BadRequest();

        var fruta = _mapper.Map<Fruta>(frutaDto);

        var novaFruta = _uof.FrutaRepository.Create(fruta);
        _uof.Commit();

        var novaFrutaDto = _mapper.Map<FrutaDTO>(novaFruta);

        return new CreatedAtRouteResult("ObterFruta",
            new { id = novaFrutaDto.FrutaId }, novaFrutaDto);
    }

    [HttpPatch("{id}/UpdatePartial")]
    public ActionResult<FrutaDTOUpdateResponse> Patch(int id, JsonPatchDocument<FrutaDTOUpdateRequest> patchFrutaDTO)
    {
        if (patchFrutaDTO is null || id <= 0)
            return BadRequest();

        var fruta = _uof.FrutaRepository.Get(c => c.FrutaId == id);

        if (fruta is null)
            return NotFound();

        var frutaUpdateRequest = _mapper.Map<FrutaDTOUpdateRequest>(fruta);

        patchFrutaDTO.ApplyTo(frutaUpdateRequest, ModelState);

        if (!ModelState.IsValid || TryValidateModel(frutaUpdateRequest))
            return BadRequest();

        _mapper.Map(frutaUpdateRequest, fruta);

        _uof.FrutaRepository.Update(fruta);
        _uof.Commit();

        return Ok(_mapper.Map<FrutaDTOUpdateResponse>(fruta));
    }


    [HttpPut("{id:int}")]
    public ActionResult<FrutaDTO> Put(int id, FrutaDTO frutaDto)
    {
        if (id != frutaDto.FrutaId)
            return BadRequest();

        var fruta = _mapper.Map<Fruta>(frutaDto);

        var frutaAtualizado = _uof.FrutaRepository.Update(fruta);
        _uof.Commit();

        var frutaAtualizadoDto = _mapper.Map<FrutaDTO>(frutaAtualizado);
        
        return Ok(frutaAtualizado);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<FrutaDTO> Delete(int id)
    {
        var fruta = _uof.FrutaRepository.Get(f => f.FrutaId == id);
        if (fruta is null)
        {
            return NotFound("Fruta não encontrada...");
        }
        var frutaDeletada = _uof.FrutaRepository.Delete(fruta);
        _uof.Commit();

        var frutaDeletadaDto = _mapper.Map<FrutaDTO>(frutaDeletada); 
        return Ok(frutaDeletada);
    }
}