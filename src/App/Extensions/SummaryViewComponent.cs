﻿using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace App.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        private readonly INotificator _notificator;

        public SummaryViewComponent(INotificator notificator)
        {
            _notificator = notificator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await Task.FromResult(_notificator.GetNotificatios());

            notifications.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Message));

            return View();
        }

    }
}
