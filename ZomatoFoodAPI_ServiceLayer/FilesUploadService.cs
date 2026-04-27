using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Interfaces;
using ZomatoFoodAPI_BusinessEntities.Models;
using ZomatoFoodAPI_BusinessEntities.StoredProcedureResponseModels;

namespace ZomatoFoodAPI_ServiceLayer
{
    public class FilesUploadService : IFilesUploadService
    {
        public readonly IFilesUploadRepository _filesUploadRepository;
        private readonly IMapper _mapper;
        public FilesUploadService(IFilesUploadRepository filesUploadRepository, IMapper mapper)
        {
            _filesUploadRepository = filesUploadRepository;
            this._mapper = mapper;
        }
        public async Task<List<FileUploadDTO>> GetFileUploadList()
        {
            var fileUploadList = await _filesUploadRepository.GetFileUploadList();
            #region before Automapper we are mapping the entiy class object to dto class object process
            //          List<FileUploadDTO> lstFileUploadDTO = new List<FileUploadDTO>();
            //          foreach (var fileUpload in fileUploadList)
            //          {
            //              FileUploadDTO fileUploadDTO = new FileUploadDTO();


            //              #region before Automapper we are mapping the entiy class object to dto class object process
            //              //fileUploadDTO.Id = fileUpload.Id;
            //              //fileUploadDTO.FileName = fileUpload.FileName;
            //              //fileUploadDTO.ModifiedFilename = fileUpload.ModifiedFilename;
            //              //fileUploadDTO.FilePath = fileUpload.FilePath;
            //              //fileUploadDTO.Createdby = fileUpload.Createdby;
            //              //fileUploadDTO.CreatedDatetTime = fileUpload.CreatedDatetTime;
            //              #endregion region

            //              lstFileUploadDTO.Add(fileUploadDTO);
            //          }
            //          return lstFileUploadDTO;
            #endregion
            //The above enire code was replaced by below single of code.
            //var result= _mapper.Map<List<FileUploadDTO>>(fileUploadList);(for debugging purpose assign into one variable and you can check)
            return _mapper.Map<List<FileUploadDTO>>(fileUploadList);//entity to dto mapping
        }
        public async Task<FileUploadDTO> GetFileUploadDetailsById(int Id)
        {//if you are using any class as a return type of method,we must return the value of that class object.this is rule
            var result = await _filesUploadRepository.GetFileUploadDetailsById(Id);
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object        
            return _mapper.Map<FileUploadDTO>(result);//entity to dto mapping
                                                      //in Service layer we are using Dto(Data transfer object) classes and return the data of Dto class object data.
            #region before Automapper we are mapping the entiy class object to dto class object process
            //FileUploadDTO fileUploadDTO = new FileUploadDTO();
            //fileUploadDTO.ModifiedFilename = result.ModifiedFilename;
            //fileUploadDTO.Id = result.Id;
            //fileUploadDTO.FileName = result.FileName;
            //fileUploadDTO.ModifiedFilename = result.ModifiedFilename;
            //fileUploadDTO.FilePath = result.FilePath;
            //fileUploadDTO.Createdby = result.Createdby;
            //fileUploadDTO.CreatedDatetTime = result.CreatedDatetTime;
            //return fileUploadDTO;
            #endregion
        }

        public async Task<FileUploadResponse> AddFileUpload(FileUploadDTO fileUploadDTO)
        {
            FileUpload obj = new FileUpload();//destinationmodelclass object
                                              //This Code was replaced by above Automapper concept.
                                              // 1)Auto mapper is used to create a mapping between  to source model object to destination model object
            _mapper.Map(fileUploadDTO, obj);//sourceobject,destinationobject

            #region before Automapper we are mapping the entiy class object to dto class object process
            //This Code was replaced by above Automapper concept.
            //obj.FileName = fileUploadDTO.FileName;
            //obj.FilePath = fileUploadDTO.FilePath;
            //obj.CreatedDatetTime = fileUploadDTO.CreatedDatetTime;
            //obj.Createdby = fileUploadDTO.Createdby;
            //obj.ModifiedFilename = fileUploadDTO.ModifiedFilename;
            //obj.Id = fileUploadDTO.Id;
            #endregion
            var result = await _filesUploadRepository.AddFileUpload(obj);
            return result;

        }
    }
}
