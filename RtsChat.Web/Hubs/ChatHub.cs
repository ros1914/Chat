﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using RtsChat.Web.Models.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RtsChat.Web.Hubs
{
	[Authorize]
	public class ChatHub : Hub
	{
		public async Task Send(string message)
		{
			await this.Clients.All.SendAsync("NewMessage", new Message
			{
				User = this.Context.User.Identity.Name,
				Text = message
			});

		}
	}
}
