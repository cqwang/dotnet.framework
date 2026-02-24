using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;

namespace Cqwang.BackEnd.CSharp.Job
{
    public partial class JobForm : Form
    {
        private IScheduler _scheduler;

        public JobForm()
        {
            InitializeComponent();
            _scheduler = new StdSchedulerFactory().GetScheduler();
            StartAll();
        }

        private void JobForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            BindData();
        }


        private void menuItemStart_Click(object sender, EventArgs e)
        {
            DoAction(this._scheduler.ResumeTrigger);
        }

        private void menuItemPause_Click(object sender, EventArgs e)
        {
            DoAction(this._scheduler.PauseTrigger);
        }

        private void menuItemFresh_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void menuItemExecute_Click(object sender, EventArgs e)
        {
            DoAction(null, (jobKey) =>
            {
                var task = Task.Factory.StartNew(() =>
                {
                    var jobType = this._scheduler.GetJobDetail(jobKey).JobType;
                    var type = jobType.Assembly.GetType(jobType.FullName);
                    var jobInstance = Activator.CreateInstance(type) as IJob;
                    if (jobInstance != null)
                    {
                        jobInstance.Execute(null);
                    }
                }).ContinueWith(t =>
                {
                    try
                    {

                    }
                    catch { }
                });
            });
        }

        private void menuItemStartAll_Click(object sender, EventArgs e)
        {
            StartAll();
        }

        private void menuItemPauseAll_Click(object sender, EventArgs e)
        {
            this._scheduler.PauseAll();
            this.timer.Stop();
            BindData();
        }


        private void DoAction(Action<TriggerKey> triggerAction, Action<JobKey> jobAction = null)
        {
            if (this.listView.SelectedItems.Count == 0)
            {
                return;
            }

            var trigger = this.listView.SelectedItems[0].Tag as ITrigger;
            if (trigger == null)
            {
                return;
            }

            if (triggerAction != null)
            {
                triggerAction(trigger.Key);
                BindData();
            }
            if (jobAction != null)
            {
                jobAction(trigger.JobKey);
            }
        }

        private void StartAll()
        {
            if (this._scheduler.IsStarted)
            {
                this._scheduler.ResumeAll();
            }
            else
            {
                this._scheduler.Start();
            }

            this.timer.Start();
        }

        private void BindData()
        {
            try
            {
                this.listView.Items.Clear();
                this.listView.Groups.Clear();
                if (this._scheduler == null || this._scheduler.IsShutdown)
                {
                    return;
                }

                var groupNames = this._scheduler.GetTriggerGroupNames();
                foreach (var groupName in groupNames)
                {
                    var group = new ListViewGroup(groupName);
                    var triggerKeys = this._scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.GroupEquals(groupName));
                    foreach (var triggerKey in triggerKeys)
                    {
                        var trigger = this._scheduler.GetTrigger(triggerKey);
                        var expression = GetTriggerExpression(trigger);
                        var state = this._scheduler.GetTriggerState(trigger.Key);
                        string previousTime, nextTime;
                        FormatTime(trigger, out previousTime, out nextTime);

                        var subItems = new string[] 
                    { 
                        trigger.JobKey.Name,
                        this._scheduler.GetJobDetail(trigger.JobKey).Description,
                        state.ToString(),previousTime,nextTime,expression
                    };
                        var item = new ListViewItem(subItems, group);
                        item.BackColor = state == TriggerState.Normal ? Color.Transparent : Color.FromArgb(255, 204, 204);
                        item.Tag = trigger;
                        this.listView.Groups.Add(group);
                        this.listView.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                this.statusLabel.Text = ex.Message;
            }
        }

        private string GetTriggerExpression(ITrigger trigger)
        {
            string expression = string.Empty;
            if (trigger is ISimpleTrigger)
            {
                ISimpleTrigger simple = (ISimpleTrigger)trigger;
                expression = "重复次数:" + (simple.RepeatCount == -1 ? "无限" : (simple.TimesTriggered.ToString() + "/" + simple.RepeatCount.ToString())) + ", 时间间隔:" + simple.RepeatInterval;
            }
            if (trigger is ICronTrigger)
            {
                ICronTrigger cron = (ICronTrigger)trigger;
                expression = cron.CronExpressionString;
            }
            return expression;
        }

        private void FormatTime(ITrigger trigger, out string previousTime, out string nextTime)
        {
            previousTime = string.Empty;
            var previous = trigger.GetPreviousFireTimeUtc();
            if (previous.HasValue && previous.Value.LocalDateTime.Date < DateTime.Now.Date)
            {
                previousTime = "- " + previous.Value.LocalDateTime.ToString("HH:mm:ss");
            }

            nextTime = string.Empty;
            var next = trigger.GetNextFireTimeUtc();
            if (next.HasValue && next.Value.LocalDateTime > DateTime.Now.Date)
            {
                nextTime = "+ " + next.Value.LocalDateTime.ToString("HH:mm:ss");
            }
        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.listView.SelectedItems.Count == 0)
            {
                this.menuItemStart.Enabled = false;
                this.menuItemPause.Enabled = false;
                this.menuItemFresh.Enabled = false;
            }
            else
            {
                var trigger = this.listView.SelectedItems[0].Tag as ITrigger;
                if (trigger == null)
                {
                    return;
                }
                var state = this._scheduler.GetTriggerState(trigger.Key);
                this.menuItemStart.Enabled = state != TriggerState.Normal;
                this.menuItemPause.Enabled = state == TriggerState.Normal;
                this.menuItemFresh.Enabled = true;
            }
        }
    }
}
