﻿using ApplicationServices;
using Connect.Helpers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;

namespace Connect.Controllers
{
    public class SkillsController : BaseController
    {
        private readonly ISkillsManager skillsManager;
        private readonly ISkillsApplicationService skillsApplicationService;

        public SkillsController(ISkillsApplicationService skillsApplicationService, ISkillsManager skillsManager)
        {
            this.skillsManager = skillsManager;
            this.skillsApplicationService = skillsApplicationService;
        }

        [HttpGet]
        public ActionResult GetSkills(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Json(new { }, JsonRequestBehavior.AllowGet);

            var matchedSkills = skillsManager.GetMatchedSkills(name);

            return Json(matchedSkills, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(string name)
        {
            return ExecuteAction(ModelState, () => 
            {
                var userId = User.Identity.GetUserId();
                var addedSkill = skillsApplicationService.Execute(new SkillDtoWriteModel(name, int.Parse(userId)));

                return addedSkill.Name;
            });
        }
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddPositionSkills(IList<string> skills, string positionId)
        {
            return ExecuteAction(ModelState, () => 
            {
                return skillsApplicationService.Execute(new PositionRequiredSkill(skills.ToArray(), long.Parse(positionId)));
            });
        }
    }
}