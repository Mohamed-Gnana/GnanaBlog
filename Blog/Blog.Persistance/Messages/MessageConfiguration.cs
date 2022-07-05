using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Common.Date;
using Blog.Domain.Messages;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Persistance.Messages
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        private readonly IDateService _dateService;

        public MessageConfiguration(IDateService dateService)
        {
            _dateService = dateService;
        }

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .HasKey(message => message.Id);

            builder
                .Property(message => message.Content)
                .IsRequired()
                .HasMaxLength(300);

            builder
                .Property(message => message.CreatedAt)
                .IsRequired();

            builder
                .Property(message => message.UpdatedAt)
                .IsRequired();

            builder
                .Property(message => message.SenderId)
                .IsRequired();

            builder
                .Property(message => message.RecieverId)
                .IsRequired();

            builder
                .HasOne(message => message.Sender)
                .WithMany(sender => sender.SentMessages)
                .HasForeignKey(message => message.SenderId)
                .HasPrincipalKey(sender => sender.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(message => message.Reciever)
                .WithMany(reciever => reciever.RecievedMessages)
                .HasForeignKey(message => message.RecieverId)
                .HasPrincipalKey(receiver => receiver.Id)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasData(
                    new Message()
                    {
                        Id = 1,
                        Content = "Admin's First message to lucky user",
                        CreatedAt = _dateService.GetDateTime(),
                        UpdatedAt = _dateService.GetDateTime(),
                        SenderId = "1",
                        RecieverId = "2"
                    }
                );
        }
    }
}
